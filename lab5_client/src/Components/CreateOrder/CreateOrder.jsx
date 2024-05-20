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
  const [feedbackText, setFeedbackText] = useState("");
  const [generalBudget, setGeneralBudget] = useState(0);
  const navigate = useNavigate();

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
    if (isSelected) {
      setSelectedServices([...selectedServices, service]);
    } else {
      setSelectedServices(selectedServices.filter((s) => s.id !== service.id));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const smeta = {
      client,
      description,
      feedbackText,
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
      setFeedbackText("");
      setGeneralBudget(0);
      setSelectedServices([]);
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
            title="Создать Смету"
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
                  value={client}
                  onChange={(e) => setClient(e.target.value)}
                  required
                />

                <label>Описание: </label>
                <Input
                  type="text"
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                  required
                />

                <label>Отзыв: </label>
                <Input
                  type="text"
                  value={feedbackText}
                  onChange={(e) => setFeedbackText(e.target.value)}
                  required
                />

                <label>Общий бюджет: </label>
                <Input
                  type="number"
                  value={generalBudget}
                  onChange={(e) => setGeneralBudget(e.target.value)}
                  required
                />

                <ServicesList onSelectService={handleServiceSelection} />

                {errorMessage && <Alert message={errorMessage} type="error" />}

                <Button type="submit">Создать</Button>
              </form>
            </div>
          </Modal>
        </React.Fragment>
      ) : (
        <React.Fragment>
          <h3>Сударь, не предложить ли Вам залогиниться?</h3>
        </React.Fragment>
      )}
    </React.Fragment>
  );
};

export default CreateOrder;
