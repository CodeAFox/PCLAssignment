from django.core.management import call_command

def load_initial_data(sender, **kwargs):
    print("loaded")
    call_command("loaddata", "categories.json")