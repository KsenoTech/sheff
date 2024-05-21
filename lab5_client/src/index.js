import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
//import App from './App';
import reportWebVitals from "./reportWebVitals";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import HomePage from "./Components/HomePage/HomePage";
import UserGet from "./Components/User/User";
import UserCreate from "./Components/Autorization/UserCreate";
import Layout from "./Components/Layout/Layout";
import LogIn from "./Components/Autorization/LogIn";
import LogOff from "./Components/Autorization/LogOff";
import AboutUs from "./Components/AboutUs/AboutUs";
import ServicesList from "./Components/ServicesList/ServicesList"; 
import OurFaces from "./Components/OurFaces/OurFaces"; 
import CreateOrder from "./Components/CreateOrder/CreateOrder"; 

const App = () => {
  const [users, setUsers] = useState([]);
  const addUser = (user) => setUsers([...users, user]);
  const removeUser = (removeId) =>
    setUsers(users.filter(({ userId }) => userId !== removeId));
  const [user, setUser] = useState({ isAuthenticated: false, userName: "", userId: "" });

  useEffect(() => {
    const getUser = async () => {
      return await fetch("api/account/isauthenticated")
        .then((response) => {
          response.status === 401 &&
            setUser({ isAuthenticated: false, userName: "", userId: "" });
          return response.json();
        })
        .then(
          (data) => {
            if (
              typeof data !== "undefined" &&
              typeof data.userName !== "undefined"
            ) {
              setUser({ isAuthenticated: true, userName: data.userName, userId: data.userId });
            }
          },
          (error) => {
            console.log(error);
          }
        );
    };
    getUser();
  }, [setUser]);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout user={user} />}>
        <Route
            index
            element={
              <div className="wrapper">
                <HomePage />
              </div>
            }
          />
          <Route
            path="/HomePage"
            element={
              <div className="wrapper">
                <HomePage />
              </div>
            }
          />
          <Route path="/ourservices" element={<ServicesList />} /> {/* Добавили новый маршрут */}
          <Route path="/ourfaces" element={<OurFaces/>}/>
          <Route path="/services" element={<CreateOrder
                                            user = {user}/>}/>
          <Route
            path="/users"
            element={
              <div>
                <UserGet
                  user={user}
                  users={users}
                  setUsers={setUsers}
                  removeUser={removeUser}
                />
              </div>
            }
          />

          <Route
            path="/login"
            element={<LogIn user={user} setUser={setUser} />}
          />

          <Route path="/logoff" element={<LogOff setUser={setUser} />} />
          <Route path="/aboutus" element={<AboutUs />} />{" "}
          <Route
            path="/usercreate"
            element={
              <div>
                <UserCreate user={user} addUser={addUser} />
              </div>
            }
          />

          <Route path="*" element={<h3>404</h3>} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  //<React.StrictMode>
  <App />
  //</React.StrictMode>
);

reportWebVitals();
