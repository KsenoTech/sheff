import React, {useState, useEffect} from "react";
 import { useNavigate } from "react-router-dom";
import { Button, Form, Input, Modal, Alert } from "antd";

const UserCreate = ({ user, addUser }) => {
  const [errorMessage, setErrorMessage] = useState("");

   const [open, setOpen] = useState(false); //стейт для хранения состояния объекта открытия окна
  const [registerFailed, setFailed] = useState(false); //стейт для хранения состояния что регистраия провалилась
  const [registerSuccess, setSuccess] = useState(false);//стейт для хранения состояния что регистраия прошла успешна
  
  const navigate = useNavigate();

  const showModal = () => { //открытие окна
    setOpen(true);
  };

  useEffect(() => {
    showModal();
  }, []);

  const handleCancel = () => {
    setOpen(false);
    navigate("/");
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    const formData = new FormData(e.target);
    const user = {};
    formData.forEach((value, key) => {
      user[key] = value;
    });
  
    // Проверка совпадения пароля и его подтверждения
    const password = formData.get("password");
    const passwordConfirm = formData.get("passwordConfirm");
    if (password !== passwordConfirm) {
      setErrorMessage("Пароль и его подтверждение не совпадают");
      return;
    }
  
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user),
    };
  
    try {
      const response = await fetch("api/account/register", requestOptions);
      if (!response.ok) {
        throw new Error("Failed to create user");
      }
      const data = await response.json();
      addUser(data);
      e.target.reset(); // Очистить форму после успешной отправки
      setSuccess(true); // Устанавливаем состояние успешной регистрации
      setOpen(false); // Закрываем модальное окно
      window.location.href = '/';
    } catch (error) {
      console.error("Error creating user:", error);
      setFailed(true); // Устанавливаем состояние неудачной регистрации
      setErrorMessage("Ошибка при создании пользователя");
    }
  };
  
  return (

    <Modal
      title="Регистрация"
      footer={null}
      open={open}
      onCancel={handleCancel}
      destroyOnClose={true}
    >
<div className="user-create-container">
      
      <form onSubmit={handleSubmit} className="user-create-form">
        <label>Фамилия: </label>
        <input
          type="text"
          name="surname"
          placeholder="Иванов"
          required/>
          
        <label>Имя: </label>
        <input type="text" name="name" placeholder="Иван" required />

        <label>Отчество: </label>
        <input type="text" name="middleName" placeholder="Иванович" />
        
        <label>Логин: </label>
        <input
          type="text"
          name="userLogin"
          placeholder="iVan1234"
          required
        />

        <label>Пароль: </label>
        <input
          type="password"
          name="password"
          placeholder="Обязательны в пароле символы: A-Z, a-z, 0-9, !?%$"
          required
        />

        <label>Повторите пароль: </label>
        <input
          type="password"
          name="passwordConfirm"
          placeholder="Обязательны в пароле символы: A-Z, a-z, 0-9, !?%$"
          required
        />


        <label>Email: </label>
        <input type="email" name="email" placeholder="mail@example.com" required />

        <label>Домашний адрес: </label>
        <input
          type="text"
          name="address"
          placeholder="Область, город, улица, дом, квартира"
          required
        />

        <label>Номер телефона: </label>
        <input
          type="tel"
          name="telephoneNumber"
          placeholder="+7-123-456-78-90"
          required
        />

 {errorMessage && <div className="error-message">{errorMessage}</div>}
 {registerSuccess && (
            <Alert message="Регистрация успешна" type="success" />
          )}
        <button type="submit">Создать</button>
      </form>
    </div>
     </Modal>
    
  );
};

export default UserCreate;
