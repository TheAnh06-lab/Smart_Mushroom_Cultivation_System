USE smart_mushroom_db;

-- 1. Vai tro nguoi dung
CREATE TABLE roles (
    role_id INT AUTO_INCREMENT PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL UNIQUE
);

-- 2. Tai khoan
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    role_id INT NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (role_id) REFERENCES roles(role_id)
);

-- 3. Phong nuoi
CREATE TABLE cultivation_rooms (
    room_id INT AUTO_INCREMENT PRIMARY KEY,
    room_name VARCHAR(100) NOT NULL,
    description TEXT,
    status VARCHAR(30) DEFAULT 'active'
);

-- 4. Khay nam
CREATE TABLE cultivation_trays (
    tray_id INT AUTO_INCREMENT PRIMARY KEY,
    room_id INT NOT NULL,
    tray_code VARCHAR(50) NOT NULL UNIQUE,
    mushroom_type VARCHAR(100),
    cultivation_stage VARCHAR(100),
    status VARCHAR(30) DEFAULT 'available',
    expected_harvest_date DATE,
    FOREIGN KEY (room_id) REFERENCES cultivation_rooms(room_id)
);

-- 5. Goi thue
CREATE TABLE rental_packages (
    package_id INT AUTO_INCREMENT PRIMARY KEY,
    package_name VARCHAR(100) NOT NULL,
    duration_days INT NOT NULL,
    price DECIMAL(12,2) NOT NULL,
    description TEXT
);

-- 6. Don thue khay
CREATE TABLE rentals (
    rental_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    tray_id INT NOT NULL,
    package_id INT NOT NULL,
    start_date DATE,
    end_date DATE,
    status VARCHAR(30) DEFAULT 'pending',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (tray_id) REFERENCES cultivation_trays(tray_id),
    FOREIGN KEY (package_id) REFERENCES rental_packages(package_id)
);

-- 7. Thiet bi IoT
CREATE TABLE iot_devices (
    device_id INT AUTO_INCREMENT PRIMARY KEY,
    room_id INT,
    device_name VARCHAR(100) NOT NULL,
    device_type VARCHAR(50) NOT NULL,
    device_code VARCHAR(100) NOT NULL UNIQUE,
    status VARCHAR(30) DEFAULT 'offline',
    FOREIGN KEY (room_id) REFERENCES cultivation_rooms(room_id)
);

-- 8. Du lieu cam bien
CREATE TABLE sensor_readings (
    reading_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    device_id INT NOT NULL,
    temperature DECIMAL(5,2),
    humidity DECIMAL(5,2),
    co2_ppm INT,
    recorded_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (device_id) REFERENCES iot_devices(device_id)
);

-- 9. Lich su thu hoach
CREATE TABLE harvest_records (
    harvest_id INT AUTO_INCREMENT PRIMARY KEY,
    tray_id INT NOT NULL,
    harvest_date DATE NOT NULL,
    quantity_kg DECIMAL(10,2),
    notes TEXT,
    FOREIGN KEY (tray_id) REFERENCES cultivation_trays(tray_id)
);

-- 10. Thong bao
CREATE TABLE notifications (
    notification_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    title VARCHAR(200) NOT NULL,
    message TEXT,
    is_read BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);