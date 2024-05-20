import React from 'react';
import "./AboutUs.css";
import fon1 from "./about.jpg"; // Импортируем изображение

const AboutUs = () => {
  return (
    <div className='custom-component'>
      <div className="horizontal-split-container">
        <div className="image-container">
          <div 
            className="background-image-about"
            style={{ backgroundImage: `url(${fon1})` }}
          ></div>
        </div>
        <div className="text-container">
          <div className="about-company">
            <div className="title">О нашей компании</div>
            <div className="description">
              Мы ценим качество и предлагаем широкий спектр услуг по ремонту помещений, начиная от косметического ремонта до полной реконструкции.
              <br /><br />
              <em>"Доверьте нам свои желания, а мы превратим их в реальность, создавая уютное и стильное жилье для вас и вашей семьи." - Лев</em>
            </div>
          </div>
        </div>
      </div>
    </div>  
  );
}

export default AboutUs;
