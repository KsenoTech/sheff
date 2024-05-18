import React from "react";
import { Outlet, Link } from "react-router-dom";
import { Layout as LayoutAntd, Menu } from "antd";

const { Header, Content, Footer } = LayoutAntd;

const items = [
  {
    label: (
      <Link
        to={"/homepage"}
        style={{
          textAlign: "center",
          fontWeight: "bold",
          fontfamily: 'Tektur',
        }}
      >
        Главная
      </Link>
    ), 
  },
  {
    label: <Link to={"/ourservices"} >Наши услуги</Link>,
    key: "2",
  },
  {
    label: <Link to={"/services"}>Ваши заказы</Link>,
    key: "3",
  },
  {
    label: <Link to="/ourfaces">Наши лица</Link>,
    key: "4",
  },
  {
    label: <Link to="/contacts">Контакты</Link>,
    key: "5",
  },
  {
    label: <Link to="/aboutus">О нас</Link>,
    key: "6",
  },
];

const Layout = ({ user }) => {
  return (
    <LayoutAntd>
      <Header style={{ position: "sticky", fontFamily: 'Tektur',  top: 0, zIndex: 1, width: "100%" }}>
        <div
          style={{
            float: "left",
            color: "rgba(255, 255, 255, 0.65)",
          }}
        ></div>

        <div
          style={{
            float: "right",
            color: "rgba(255, 255, 255, 0.65)",
          }}
        >
          {!user.isAuthenticated && (
            <span style={{ paddingRight: "20px" }}>
              {<strong>Гость</strong>}
            </span>
          )}

          {user.isAuthenticated && (
            <span style={{ paddingRight: "20px" }}>{user.userLogin}</span>
          )}
          {!user.isAuthenticated && <Link to="/login">Вход </Link>}
          {user.isAuthenticated && <Link to="/logoff">Выход </Link>}

          {!user.isAuthenticated && <Link to="/userCreate"> Регистрация</Link>}
        </div>

        <Menu style={{ fontFamily: 'Tektur'}} theme="dark" mode="horizontal" items={items} className="menu" />
      </Header>

      <Content className="site-layout">
        <Outlet />
      </Content>

      {!window.location.pathname.includes("/homepage") && (
        <Footer style={{ textAlign: "center" }}>
          {new Date().getFullYear()} &copy; KLMych Team. Все права защищены.
        </Footer>
      )}
    </LayoutAntd>
  );
};
export default Layout;
