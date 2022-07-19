# Наследование применяется там, где можно выделить общие свойство/поведение обьектов класса.
# Например, домашние животные. Они все имеют 4 ноги и хвост. Но кричат по разному...


class Pet:
    """ Домашнее животное """
    legs = 4
    has_tail = True

    def inspect(self):
        print('Всего ног:', self.legs)
        print('Хвост присутствует -', 'да' if self.has_tail else 'нет')


class Cat(Pet):
    """ Кошка - является Домашним Животным """

    def sound(self):
        print('Мяу!')


class Dog(Pet):
    """ Собака - является Домашним Животным """

    def sound(self):
        print('Гав!')


class Hamster(Pet):
    """ Хомячок - является Домашним Животным """

    def sound(self):
        print('Ццццццц!')


print("Котик")
my_pet = Cat()
my_pet.inspect()
my_pet.sound()

print("Собачка")
my_pet = Dog()
my_pet.inspect()
my_pet.sound()

print("Хомячок")
my_pet = Hamster()
my_pet.inspect()
my_pet.sound()


###############################################


class CanFly:

    def __init__(self):
        self.altitude = 0  # метров
        self.velocity = 0  # км/ч

    def take_off(self):
        pass

    def fly(self):
        pass

    def land_on(self):
        self.altitude = 0
        self.velocity = 0

    def __str__(self):
        return '{} высота {} скорость {}'.format(
            self.__class__.__name__, self.altitude, self.velocity)


class Butterfly(CanFly):

    def take_off(self):
        self.altitude = 1

    def fly(self):
        self.velocity = 0.1


class Aircraft(CanFly):

    def take_off(self):
        self.velocity = 300
        self.altitude = 1000

    def fly(self):
        self.velocity = 800


class Missile(CanFly):

    def take_off(self):
        self.velocity = 1000
        self.altitude = 10000

    def land_on(self):
        self.altitude = 0
        self.destroy_enemy_base()

    def destroy_enemy_base(self):
        print('БА-БАХ!')


butterfly = Butterfly()
print(butterfly)
butterfly.take_off()
print(butterfly)
butterfly.fly()
print(butterfly)
butterfly.land_on()
print(butterfly)

missile = Missile()
print(missile)
missile.take_off()
print(missile)
missile.fly()
print(missile)
missile.land_on()
print(missile)


###############################################


class Employee:
    """ Работник """

    def salary(self):
        """ Зарплата """
        return 15000


class Parent:
    """ Родитель """

    def childrens(self):
        """ Дети """
        return ['Вася', 'Катя']


class Man(Parent, Employee):
    """ Человек - является и Родителем и Работником """
    pass


me = Man()
print(me.childrens())
print(me.salary())


###############################################


class GrandParent:

    def method(self):
        print('call from GrandParent')


class ParentOne(GrandParent):

    def method(self):
        super().method()
        print('call from ParentOne')


class ParentTwo(GrandParent):

    def method(self):
        super().method()
        print('call from ParentTwo')


class Child(ParentOne, ParentTwo, ):

    def method(self):
        super().method()
        print('call from Child')


obj = Child()
obj.method()
print(obj.__class__.__mro__)


###############################################


class Robot:

    def __init__(self, model, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.model = model

    def __str__(self):
        res = super().__str__()
        return res + ' {} model {}'.format(self.__class__.__name__, self.model)

    def operate(self):
        print('Робот ездит по кругу')


class CanFly:

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.altitude = 0  # метров
        self.velocity = 0  # км/ч

    def take_off(self):
        self.altitude = 100
        self.velocity = 300

    def fly(self):
        self.altitude = 5000

    def land_on(self):
        self.altitude = 0
        self.velocity = 0

    def operate(self):
        super().operate()
        print('летим')

    def __str__(self):
        res = super().__str__()
        return res + ' {} высота {} скорость {}'.format(
            self.__class__.__name__, self.altitude, self.velocity)


class Drone(CanFly, Robot, ):

    def __init__(self, model, gun):
        super().__init__(model=model)
        self.gun = gun

    def operate(self):
        super().operate()
        print('Робот ведет разведку с воздуха')


orbiter = Drone(model='Orbiter II', gun='пулемет')
print(orbiter)
orbiter.take_off()
print(orbiter)
orbiter.fly()
print(orbiter)
orbiter.operate()
print(orbiter)
orbiter.land_on()
print(orbiter)


###############################################