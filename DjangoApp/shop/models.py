from django.db import models
from django.core.exceptions import ValidationError

PAYMENT_TYPE_CHOICES = [
    ('MPAY', 'MobilePay'),
    ('CREDIT_CARD', 'Credit Card'),
    ('VIA_CARD', 'VIA card'),
    ('CASH', 'Cash')
]

ORDER_STATUSES = [
    (0, 'CREATED'),
    (1 ,'DELIVERED'),
    (2, 'PAID')
]

# Create your models here.
class Payment(models.Model):
    payment_type = models.CharField(max_length=11, choices=PAYMENT_TYPE_CHOICES)
    total_price = models.DecimalField(max_digits=8, decimal_places=2)
    phone_number = models.CharField(max_length=8, blank=True)
    card_number = models.CharField(max_length=16, blank=True)   
    card_cvv = models.CharField(max_length=3, blank=True)       
    card_expiry = models.DateField(null=True, blank=True)
    via_id = models.CharField(max_length=6, blank=True) 

# payments validation
    def clean(self):
        valid_payment_types = [c[0] for c in PAYMENT_TYPE_CHOICES]
        if self.payment_type not in valid_payment_types or self.payment_type is None:
                raise ValidationError("Please select correct payment type.", code="required")
        elif self.payment_type == 'CREDIT_CARD':
            if len(self.card_number) != 16:
                raise ValidationError("Card number must be 16 digits.", code="invalid")
            elif len(self.card_cvv) != 3:
                raise ValidationError("Card cvv must be 3 digits.", code="invalid")
        elif self.payment_type == 'MPAY':
            if not self.phone_number or len(self.phone_number) != 8:
                raise ValidationError("MobilePay requires an 8 digit phone number.", code="required")
        elif self.payment_type == 'VIA_CARD':
            if len(self.via_id) != 6:
                raise ValidationError("VIAID requires an 6 digit number.", code="invalid")
        elif self.payment_type == 'CASH':
            if self.total_price <= 0:
                raise ValidationError("Cash amount must be positive.", code="invalid")
            
class Order(models.Model):
    order_status = models.IntegerField(choices=ORDER_STATUSES, default=0)
    payment = models.ForeignKey(Payment, on_delete=models.SET_NULL, null=True)