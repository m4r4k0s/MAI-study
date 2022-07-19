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