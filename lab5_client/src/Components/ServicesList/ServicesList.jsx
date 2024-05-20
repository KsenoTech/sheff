import React, { useEffect, useState } from "react";
import ServiceCard from "./ServiceCard";
import "./ServicesList.css";

const ServicesList = ({onSelectService, isSelectionEnabled }) => {
  const [services, setServices] = useState([]);
  const [error, setError] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedServices, setSelectedServices] = useState([]);

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

  const handleSearch = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleSelectService = (service) => {
    const isSelected = selectedServices.some((s) => s.id === service.id);
    if (isSelectionEnabled) {
      const updatedSelectedServices = isSelected
        ? selectedServices.filter((s) => s.id !== service.id)
        : [...selectedServices, service];
      setSelectedServices(updatedSelectedServices);
      onSelectService(service, !isSelected);
    } else {
      onSelectService(service, isSelected);
    }
  };

  const filteredServices = services.filter(
    (service) =>
      service.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
      service.description.toLowerCase().includes(searchTerm.toLowerCase())
  );

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="services-list">
      <input
        type="text"
        placeholder="Поиск..."
        value={searchTerm}
        onChange={handleSearch}
        className="search-input"
      />
      <div className="service-cards">
        {filteredServices.map((service) => (
          <ServiceCard
            key={service.id}
            service={service}
            isSelected={selectedServices.some((s) => s.id === service.id)}
            onSelect={handleSelectService}
            isSelectionEnabled={isSelectionEnabled}
          />
        ))}
      </div>
    </div>
  );
};

export default ServicesList;
