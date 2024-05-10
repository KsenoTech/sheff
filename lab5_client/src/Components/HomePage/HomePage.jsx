import React from 'react';
 import "./Style.css";
 import fon1 from "./fon1.jpg"; // Импортируем изображение

const HomePage = () => {
  return (
    <div className='custom-component'>
      <div 
        className="background-image"
        style={{ backgroundImage: `url(${fon1})`
      }}
        >
        <div className="overlay"></div>
        <div className="text-wrapper">
          <div className="main-text">Шеф-Построит!</div>
          <div className="secondary-text">Мы ценим качество</div>
        </div>3
        <div className="Footer">
        {new Date().getFullYear()} &copy; KLMych Team. Все права защищены.
        </div>
      </div>
    </div>
      
  );
}

export default HomePage;
