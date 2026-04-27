from django.apps import AppConfig
from django.db.models.signals import post_migrate
from .signals import load_initial_data


class ShopConfig(AppConfig):
    name = 'shop'

    def ready(self):
        print("To load initial data, run 'python manage.py migrate'")
        post_migrate.connect(load_initial_data, sender=self)
