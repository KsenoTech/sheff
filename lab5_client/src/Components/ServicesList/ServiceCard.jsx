import React from "react";
import "./ServicesList.css";

const ServiceCard = ({ service, isSelected, onSelect, isSelectionEnabled }) => {
  const serviceClassName = isSelected && isSelectionEnabled ? "selected-service" : "service";

  // Отображаем стоимость в зависимости от наличия значений
  const costDisplay = () => {
    if (service.costOfM != null && service.costOfM2 == null) {
      return <p>Стоимость за м: {service.costOfM} руб.</p>;
    } else if (service.costOfM == null && service.costOfM2 != null) {
      return <p>Стоимость за м²: {service.costOfM2} руб.</p>;
    } else if (service.costOfM != null && service.costOfM2 != null) {
      if (service.costOfM === service.costOfM2) {
        return <p>Стоимость: {service.costOfM} руб.</p>;
      } else {
        return (
          <>
            <p>Стоимость за м: {service.costOfM} руб.</p>
            <p>Стоимость за м²: {service.costOfM2} руб.</p>
          </>
        );
      }
    } else {
      return <p>Стоимость не указана</p>;
    }
  };

  return (
    <div className={serviceClassName} onClick={() => onSelect(service)}>
      <div className="service-card">
        <h3>{service.title}</h3>
        <p>{service.description}</p>
        {costDisplay()}
      </div>
    </div>
  );
};
export default ServiceCard;
