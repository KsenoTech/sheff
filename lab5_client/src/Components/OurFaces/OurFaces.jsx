import React from 'react';
import './OurFaces.css'; // Подключаем файл стилей
import image1 from './img/я.jpg';
import image2 from './img/шеф.jpg';
import image3 from './img/z2.jpg';
import image4 from './img/я2.jpg';

const teamMembers = [
  {
    name: 'Ксенофонтов Лев',
    title: 'Генеральный директор KLMych Team',
    image: image1
  },
  {
    name: 'Федосеев Олег',
    title: 'Исполнительный директор Шеф-Построит!',
    image: image2
  },
  {
    name: 'Julia Bush',
    title: 'Design Director',
    image: image3
  },
  {
    name: 'Carlos Lott',
    title: 'Marketing Director',
    image: image4
  }
];

const OurFaces = () => {
  return (
    <div className="our-faces">
      <div className="section-container">
        <div className="section-topwrapper">
          <div className="section-title">Кто мы такие</div>
          <div className="section-descr">
            Каждый день наши специалисты работают над предоставлением лучших услуг и решений, чтобы радовать наших клиентов.
          </div>
        </div>
        <ul className="team-container">
          {teamMembers.map((member, index) => (
            <li key={index} className="team-item">
              <div className="item-wrapper">
                <div
                  className="item-bgimg"
                  style={{ backgroundImage: `url(${member.image})` }}
                ></div>
                <div className="item-info">
                  <div className="item-name">{member.name}</div>
                  <div className="item-title">{member.title}</div>
                </div>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default OurFaces;
