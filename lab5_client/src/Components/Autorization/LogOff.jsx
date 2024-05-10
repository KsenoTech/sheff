import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Modal, Button } from "antd";

const LogOff = ({ setUser }) => {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);

  const showModal = () => {
    setOpen(true);
  };

  const handleCancel = () => {
    setOpen(false);
  };

  const handleLogOff = (event) => {
    logOff(event);
    setOpen(false);
  };

  const logOff = async (event) => {
    event.preventDefault();

    const requestOptions = {
      method: "POST",
    };

    await fetch("api/account/logoff", requestOptions)
      .then((response) => {
        if (response.status === 200) {
          setUser({ isAuthenticated: false, userName: "" });
          // Переход на корневой маршрут после успешного выхода
          navigate("/");
        } else if (response.status === 401) {
          // Переход на страницу входа в случае, если пользователь не авторизован
          navigate("/login");
        }
      })
      .catch((error) => {
        console.error("Ошибка при выполнении выхода:", error);
      });
  };

  useEffect(() => {
    showModal(); // Показываем модальное окно при загрузке компонента
  }, []);

  return (
      <Modal 
      style={{ textAlign: "center"}}
        title="Уже уходите?" 
        footer={null} 
        visible={open} 
        onCancel={handleCancel}
        >
          
        <Button 
          type="primary" 
          danger 
          onClick={handleLogOff}
          style={{ display: "block", margin: "auto" }}
        >
          Да, но скоро вернусь!
        </Button>

      </Modal>
  );
};

export default LogOff;
