from django.apps import AppConfig


class ShopConfig(AppConfig):
    name = 'shop'

    def ready(self):
        print("To get all data, run 'python manage.py migrate'")