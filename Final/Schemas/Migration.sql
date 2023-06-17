CREATE TABLE IF NOT EXISTS movies(
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    genre INTEGER,
    duration FLOAT,
    rating FLOAT
);

CREATE TABLE IF NOT EXISTS showtimes(
    id SERIAL PRIMARY KEY,
    film_name TEXT NOT NULL,
    date TIMESTAMP,
    film_id INTEGER,
    FOREIGN KEY (film_id) REFERENCES movies(id)
);