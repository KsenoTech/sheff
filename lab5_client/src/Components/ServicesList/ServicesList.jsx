import React, { useEffect, useState } from "react";
import ServiceCard from "./ServiceCard";
import "./ServicesList.css";

const ServicesList = () => {
  const [services, setServices] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await fetch("api/ourservice/getall");
        const data = await response.json();
        if (response.ok) {
          setServices(data.services);
        } else {
          setError(data.message);
        }
      } catch (error) {
        setError("Ошибка при загрузке данных");
      }
    };

    fetchServices();
  }, []);

  const groupedServices = services.reduce((acc, service) => {
    if (!acc[service.Title]) {
      acc[service.Title] = [];
    }
    acc[service.Title].push(service);
    return acc;
  }, {});

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="services-list">
      {Object.keys(groupedServices).map((title) => (
        <div key={title} className="service-category">
          <h2>{title}</h2>
          <div className="service-cards">
            {groupedServices[title].map((service) => (
              <ServiceCard key={service.Id} service={service} />
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};

export default ServicesList;
