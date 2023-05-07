CREATE TABLE weather (
  id INT PRIMARY KEY,
  name VARCHAR(50),
  city VARCHAR(100)
);

-- Veri ekleme
INSERT INTO County (id, name, city)
VALUES (1, 'Germany', 'Berlin'),
       (2, 'Russia', 'Moscow');

-- Veri sorgulama
SELECT * FROM County;

-- Tablo güncelleme
UPDATE Country
SET city = 'newCity'
WHERE id = 1;

-- Veri silme
DELETE FROM Country
WHERE id = 2;