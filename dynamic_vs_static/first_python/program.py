import pymongo

def add_data(db):
    cars = db.cars

    c = {
        "name": "Tesla",
        "model": "Model S",
        "colors": [
            { "name": "white", "price": 12.0 },
            { "name": "black", "price": 9.0 },
        ]
    }

    cars.save(c)

    c = {
        "name": "Esprite",
        "model": "Lotus",
        "colors": [
            { "name": "yellow", "price": 15.0 },
        ]
    }

    cars.save(c)

def query_data():
    pass

def create_connection():
    client = pymongo.MongoClient()
    db = client.FirstPython
    return db


def main():
    db = create_connection()
    add_data(db)


main()