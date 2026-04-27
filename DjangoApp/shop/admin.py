from django.contrib import admin
from .models import Category, Product, Payment, Order
# Register your models here.
# To log in on the admin site, a superuser needs to be created
# Run the command: 'python manage.py createsuperuser'
admin.site.register(Category)
admin.site.register(Product)
admin.site.register(Payment)
admin.site.register(Order)