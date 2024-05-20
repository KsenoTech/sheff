import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, Input, Modal } from "antd";

const LogIn = ({ user, setUser }) => {
  const [errorMessages, setErrorMessages] = useState([]);
  const navigate = useNavigate();
  const [form] = Form.useForm(); // Добавляем хук для работы с формой
  const [open, setOpen] = useState(false); //стейт для хранения состояния объекта открытия окна
  
  const showModal = () => {
    //открытие модального окна
    setOpen(true);
  };

  useEffect(() => {
    //это позволяет синхронизироваться с внешней системой.
    showModal();
  }, []);

  const handleCancel = () => {
    //отмена входа
    setOpen(false);
    navigate("/");
  };

  const logIn = async () => {
    try {
      const values = await form.validateFields(); // Проверяем валидность полей
      const { userLogin, password } = values;

      const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userLogin, password }),
      };

      const response = await fetch("api/account/login", requestOptions);
      const data = await response.json();

      if (response.status === 200 && data.userName) {
        setUser({ isAuthenticated: true, userName: data.userName });
        navigate("/");
      } else if (data.error) {
        setErrorMessages([data.error]);
      }
    } catch (errorInfo) {
      console.log("Failed:", errorInfo);
    }
  };

  const renderErrorMessage = () =>
    errorMessages.map((error, index) => <div key={index}>{error}</div>);

  return (
    <>
      {user.isAuthenticated ? (
        <h3>Пользователь {user.userName} успешно вошел в систему</h3>
      ) : (
        <Modal //модальное окно
        title="Вход"
        footer={null}
        open={open}
        onCancel={handleCancel}
        destroyOnClose={true}
      >
         
          <Form
            form={form}
            onFinish={logIn} // Используем onFinish вместо onSubmit
            name="basic"
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            style={{ maxWidth: 600 }}
            autoComplete="off"
          >
            <Form.Item
              label="Логин"
              name="userLogin"
              rules={[{ required: true, message: "Пожалуйста, введите логин!" }]}
            >
              <Input />
            </Form.Item>

            <Form.Item
              label="Пароль"
              name="password"
              rules={[{ required: true, message: "Пожалуйста, введите пароль!" }]}
            >
              <Input.Password />
            </Form.Item>

           

            <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
              <Button type="primary" htmlType="submit">
                Вход
              </Button>
            </Form.Item>

          </Form>
        </Modal>
      )}
    </>
  );
};

export default LogIn;
