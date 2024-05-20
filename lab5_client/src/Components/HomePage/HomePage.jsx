import React from 'react';
 import "./StyleHome.css";
 import fon1 from "./fon1.jpg"; // Импортируем изображение

const HomePage = () => {
  return (
    <div className='home-page'>
      <div 
        className="background-image"
        style={{ backgroundImage: `url(${fon1})`
      }}
        >
        <div className="overlay"></div>
        <div className="text-wrapper">
          <div className="main-text">Шеф-Построит!</div>
          <div className="secondary-text">Мы ценим качество</div>
        </div>
        <div className="Footer">
        {new Date().getFullYear()} &copy; KLMych Team. Все права защищены.
        </div>
      </div>
    </div>
      
  );
}

export default HomePage;