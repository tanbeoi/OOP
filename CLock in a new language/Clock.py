class Counter:
    def __init__(self, name):
        self._count = 0
        self._name = name

    def increment(self):
        self._count += 1

    def reset(self):
        self._count = 0

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def ticks(self):
        return self._count


class Clock:
    def __init__(self):
        self._hours = Counter("Hours")
        self._minutes = Counter("Minutes")
        self._seconds = Counter("Seconds")

    def tick(self):
        self._seconds.increment()
        if self._seconds.ticks == 60:
            self._seconds.reset()
            self._minutes.increment()
            if self._minutes.ticks == 60:
                self._minutes.reset()
                self._hours.increment()
                if self._hours.ticks == 24:
                    self._hours.reset()

    def reset(self):
        self._hours.reset()
        self._minutes.reset()
        self._seconds.reset()

    def display(self):
        display_str = f"{self._hours.ticks:02}:{self._minutes.ticks:02}:{self._seconds.ticks:02}"
        print(display_str)
        return display_str


def main():
    clock = Clock()

    for i in range(90000):
        clock.tick()
        if i % 86400 == 0:
            clock.reset()
        clock.display()


if __name__ == "__main__":
    main()
