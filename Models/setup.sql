CREATE TABLE keeps (
    id INT NOT NULL AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    imgurl VARCHAR(255) NOT NULL,
    isPrivate TINYINT NOT NULL,
    PRIMARY KEY (id)
)