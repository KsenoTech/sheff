import React, { useEffect, useState } from "react";
import "./Style.css";

const UserGet = ({user}) => {
//   const [users, setUsers] = useState({
//     isAuthenticated: false
// });
const [users, setUsers] = useState([]);

  useEffect(() => {
    updateUserWithProvidedServiceList();
  }, []);

  const updateUserWithProvidedServiceList = async () => {
    try {
      const response = await fetch("api/users/UserWithProvidedServices");
      const data = await response.json();
      setUsers(data);
    } catch (error) {
      console.error("Error updating users:", error);
    }
  };

  const deleteItem = async (id) => {
    const requestOptions = {
      method: "DELETE",
    };
    try {
      const response = await fetch("api/users/" + id, requestOptions);
      if (response.ok) {
        updateUserWithProvidedServiceList();
      }
    } catch (error) {
      console.error("Error deleting user:", error);
    }
  };

  const updateItem = async (updatedUser) => {
    const requestOptions = {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedUser),
    };
    return await fetch("api/users/" + updatedUser.id, requestOptions)
    .then((response) => {
        if (response.ok) {
          updateUserWithProvidedServiceList();
        }
      },
      (error) => console.log(error)
    );
  };

  const updateUser = (user) => {
    const userInput1 = prompt("Введите новое имя:", user.name);
    if (userInput1 !== null) {
      const userInput2 = prompt("Введите новую фамилию:", user.surname);
      if (userInput2 !== null) {
        const userInputEmail = prompt("Введите новый email:", user.email);
        if (userInputEmail !== null) {
          const userInputPassword = prompt(
            "Введите новый пароль:",
            user.password
          );
          if (userInputPassword !== null) {
            const userInputAddress = prompt(
              "Введите новый адрес:",
              user.address
            );
            if (userInputAddress !== null) {
              const userInputTelephoneNumber = prompt(
                "Введите новый номер телефона:",
                user.telephoneNumber
              );
              if (userInputTelephoneNumber !== null) {
                const userInputKolvoZakazov = prompt(
                  "Введите новое количество заказов:",
                  user.kolvoZakazov
                );
                if (
                  !isNaN(userInputKolvoZakazov) &&
                  userInputKolvoZakazov !== null
                ) {
                  const userInputRating = prompt(
                    "Введите новый рейтинг:",
                    user.rating
                  );
                  if (!isNaN(userInputRating) && userInputRating !== null) {
                    const userInputMiddleName = prompt(
                      "Введите новое отчество:",
                      user.middleName
                    );
                    if (userInputMiddleName !== null) {
                      const userInputLogin = prompt(
                        "Введите новый логин:",
                        user.login
                      );
                      if (userInputLogin !== null) {
                        const updatedUser = {
                          ...user,
                          name: userInput1,
                          surname: userInput2,
                          email: userInputEmail,
                          password: userInputPassword,
                          address: userInputAddress,
                          telephoneNumber: userInputTelephoneNumber,
                          kolvoZakazov: parseInt(userInputKolvoZakazov),
                          rating: parseFloat(userInputRating),
                          middleName: userInputMiddleName,
                          userName: userInputLogin,
                          userLogin: userInputLogin,
                        };
                        updateItem(updatedUser);
                      } else {
                        alert("Отменено или введены некорректные данные");
                      }
                    } else {
                      alert("Отменено или введены некорректные данные");
                    }
                  } else {
                    alert("Отменено или введены некорректные данные");
                  }
                } else {
                  alert("Отменено или введены некорректные данные");
                }
              } else {
                alert("Отменено или введены некорректные данные");
              }
            } else {
              alert("Отменено или введены некорректные данные");
            }
          } else {
            alert("Отменено или введены некорректные данные");
          }
        } else {
          alert("Отменено или введены некорректные данные");
        }
      } else {
        alert("Отменено или введены некорректные данные");
      }
    } else {
      alert("Отменено или введены некорректные данные");
    }
  };

  function CanCRUDUser(puser) {
    if (puser.userRole === "admin") {
        return (
            <div>
                <h4>Ваши заказы:</h4>
                <ul>
                    {puser.users.map(pop => (
                        <li key={pop.id}>
                            {pop.model}: {pop.cost}
                        </li>
                    ))}
                </ul>
                <button onClick={(e) => deleteItem(user.id)}>Удалить</button>
                <button onClick={(e) => updateUser(user)}>Обновить</button>
            </div>
        )
    }
}
  return (
    <React.Fragment>
      {user.isAuthenticated ? (
         <React.Fragment>
          <div className="user-container">
            <h3>Пользователи и предоставляемые ими услуги</h3>
            {users.map((user) => (
              <div className="user-card" key={user.id}>
                <div className="user-info">
                  <strong>Имя пользователя:</strong> {user.name}
                </div>
                <div className="provided-services">
                  <strong>Предоставляемые услуги:</strong>
                  <ul>
                    {user.providedServices && user.providedServices.length > 0 ? 
                    (
                      user.providedServices.map((service) => (
                        <li key={service.id}>
                          {service.title}: {service.description}
                        </li>
                      ))
                    ) : (
                      <li>Услуги не предоставлены</li>
                    )}
                  </ul>
                </div>
                <div className="user-actions">
                  {/* <button onClick={() => updateUser(user)}>Обновить</button>
                  <button onClick={() => deleteItem(user.id)}>Удалить</button> */}
                  {CanCRUDUser(user)}
                </div>
              </div>
            ))}
          </div> 
          </React.Fragment>) : (
        <React.Fragment>
          <h3>Сударь, не предложить ли Вам залогиниться?</h3>
        </React.Fragment>
      )}
    </React.Fragment>
  );
};

export default UserGet;
