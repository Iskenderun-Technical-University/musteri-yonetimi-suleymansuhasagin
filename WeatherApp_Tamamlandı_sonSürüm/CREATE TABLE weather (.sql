CREATE TABLE weather (
  id INT PRIMARY KEY,
  name VARCHAR(50),
  city VARCHAR(100)
);

CREATE TABLE cities (
  city_id INT NOT NULL AUTO_INCREMENT,
  city_name VARCHAR(50) NOT NULL,
  country VARCHAR(50) NOT NULL,
  PRIMARY KEY (city_id)
);

CREATE TABLE weather_reports (
  report_id INT NOT NULL AUTO_INCREMENT,
  city_id INT NOT NULL,
  condition_id INT NOT NULL,
  temp_celsius FLOAT NOT NULL,
  humidity FLOAT NOT NULL,
  wind_speed FLOAT NOT NULL,
  report_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (city_id) REFERENCES cities(city_id),
  FOREIGN KEY (condition_id) REFERENCES weather_conditions(condition_id),
  PRIMARY KEY (report_id)
);

INSERT INTO cities (city_name, country) VALUES
  ('New York', 'USA'),
  ('London', 'UK'),
  ('Paris', 'France'),
  ('Tokyo', 'Japan');
  
INSERT INTO weather_conditions (condition_name) VALUES
  ('Clear'),
  ('Clouds'),
  ('Rain'),
  ('Snow'),
  ('Thunderstorm'),
  ('Drizzle'),
  ('Mist');

INSERT INTO weather_reports (city_id, condition_id, temp_celsius, humidity, wind_speed)
  VALUES
  (1, 2, 15.5, 63.0, 13.4),
  (1, 1, 23.1, 45.6, 8.2),
  (2, 3, 10.9, 81.2, 22.1),
  (3, 2, 18.3, 54.1, 9.3),
  (3, 6, 12.8, 73.2, 11.5),
  (4, 2, 22.0, 59.7, 5.8),
  (4, 3, 16.5, 84.3, 7.2);

SELECT * FROM County;


UPDATE Country
SET city = 'newCity'
WHERE id = 1;


DELETE FROM Country
WHERE id = 2;