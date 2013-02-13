from django.db import models

class Designers(models.Model):
	name = models.CharField(max_length=100)

class ProgrammingLanguages(models.Model):
	name = models.CharField(max_length=100)

class Projects(models.Model):
	name = models.CharField(max_length=200)
	project_image = models.CharField(max_length=200)
	pub_date = models.DateTimeField('date published')
	url = models.CharField(max_length=200)
	programming_language = models.ForeignKey(ProgrammingLanguages)
	designer = models.ForeignKey(Designers)
