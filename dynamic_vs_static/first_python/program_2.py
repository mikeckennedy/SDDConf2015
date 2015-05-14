import mongoengine

class Car(mongoengine.document.Document):
    meta = {"collection": "cars"}

    model = mongoengine.StringField(required=True)
    type = mongoengine.StringField()


car = Car(model="Model S", type="Tesla")
car.save()