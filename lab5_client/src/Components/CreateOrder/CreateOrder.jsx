import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, Input, Modal, Alert } from "antd";
import ServicesList from "../ServicesList/ServicesList";

const CreateOrder = ({ user }) => {
  console.log(user);

  const [errorMessage, setErrorMessage] = useState("");
  const [open, setOpen] = useState(false);
  const [selectedServices, setSelectedServices] = useState([]);
  const [client, setClient] = useState("");
  const [description, setDescription] = useState("");
  const [generalBudget, setGeneralBudget] = useState(0);
  const navigate = useNavigate();

  const [roomArea, setRoomArea] = useState(0);
  const [ceilingHeight, setCeilingHeight] = useState(0);

  const showModal = () => {
    setOpen(true);
  };

  useEffect(() => {
    showModal();
  }, []);

  const handleCancel = () => {
    setOpen(false);
    navigate("/");
  };

  const handleServiceSelection = (service, isSelected) => {
    const updatedSelectedServices = isSelected
      ? [...selectedServices, service]
      : selectedServices.filter((s) => s.id !== service.id);

    setSelectedServices(updatedSelectedServices);

    // Вычисление общей суммы бюджета
    const totalBudget = updatedSelectedServices.reduce((acc, s) => {
      const cost = s.costOfM2 ?? s.costOfM;
      return acc + (cost * roomArea * ceilingHeight);
    }, 0);
    setGeneralBudget(totalBudget);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();


    const smeta = {
      client,
      description,
      generalBudget,
      services: selectedServices.map((service) => service.id),
    };

    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(smeta),
    };

    try {
      const response = await fetch("/api/smeta/createone", requestOptions);
      if (!response.ok) {
        throw new Error("Failed to create smeta");
      }
      const data = await response.json();
      alert("Смета успешно создана!");
      setClient("");
      setDescription("");
      setGeneralBudget(0);
      setSelectedServices([]);
      setCeilingHeight(0);
      setRoomArea(0);
      setOpen(false);
    } catch (error) {
      console.error("Error creating smeta:", error);
      setErrorMessage(`Ошибка при создании сметы: ${error.message}`);
    }
  };

  return (
    <React.Fragment>
      {user && user.isAuthenticated ? (
        <React.Fragment>
          <Modal
            title={<div style={{ textAlign: 'center', fontSize: "20px" }}>Заказ на ремонт</div>}
            footer={null}
            open={open}
            onCancel={handleCancel}
            destroyOnClose={true}
          >
            <div className="create-smeta-container">
              <form onSubmit={handleSubmit} className="create-smeta-form">
                <label>Клиент: </label>
                <Input
                  type="text"
                  value={user.smeta}
                  onChange={(e) => setClient(e.target.value)}
                  defaultValue={user.userName}
                  required
                />

                <label>Описание: </label>
                <Input
                  type="text"
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                  required
                />

                <label>Площадь комнаты (м²):</label>
                <Input
                  type="number"
                  value={roomArea}
                  onChange={(e) => setRoomArea(Number(e.target.value))}
                  required
                />

                <label>Высота потолков (м):</label>
                <Input
                  type="number"
                  value={ceilingHeight}
                  onChange={(e) => setCeilingHeight(Number(e.target.value))}
                  required
                />

                <label>Общий бюджет: </label>
                <Input
                  type="number"
                  value={generalBudget}
                  onChange={(e) => setGeneralBudget(Number(e.target.value))}
                  required
                />

                <ServicesList onSelectService={handleServiceSelection}
                 isSelectionEnabled={true} />

                {errorMessage && <Alert message={errorMessage} type="error" />}

                <Button type="submit">Создать</Button>
              </form>
            </div>
          </Modal>
        </React.Fragment>
      ) : (
        <React.Fragment>
          <div
            style={{
              textAlign: "center",
              padding: "20px",
              backgroundColor: "#f0f0f0",
              borderRadius: "5px",
            }}
          >
            <h3 style={{ color: "#083B5B" }}>
              Сударь, не предложить ли Вам залогиниться?
            </h3>
          </div>
        </React.Fragment>
      )}
    </React.Fragment>
  );
};

export default CreateOrder;
