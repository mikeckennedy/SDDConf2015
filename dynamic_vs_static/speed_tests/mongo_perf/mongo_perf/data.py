import pymongo

def get_data():
    client = pymongo.MongoClient()
    db = client.BookStore
    count = db.Book.count()
    book = db.Book.find_one({'ISBN': '0671004530'})

    return (count, book)

