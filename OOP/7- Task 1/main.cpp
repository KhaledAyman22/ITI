#include <iostream>
#include <conio.h>

using namespace std;

class GeometricShape{
    int d1,d2;

public:
    GeometricShape(){ d1 = d2 = 0;}

    GeometricShape(int d1, int d2) : d1(d1), d2(d2) {}

    int getD1() const {
        return d1;
    }

    void setD1(int d1) {
        GeometricShape::d1 = d1;
    }

    int getD2() const {
        return d2;
    }

    void setD2(int d2) {
        GeometricShape::d2 = d2;
    }

    virtual double CalcArea() = 0;
};

class Circle : public GeometricShape{
    int r;
public:
    Circle(){}

    Circle(int r) : GeometricShape(r, r), r(r) {}

    int getR() const {
        return r;
    }

    void setR(int r) {
        Circle::r = r;
        setD1(r);
        setD2(r);
    }

    double CalcArea(){
        return 3.14 * getD1() * getD2();
    }
};

class Triangle : public GeometricShape{
public:
    Triangle(){}

    Triangle(int d1, int d2) : GeometricShape(d1, d2) {}

    double CalcArea(){
        return 0.5 * getD1() * getD2();
    }
};

class Rectangle : public GeometricShape{
public:
    Rectangle(){}

    Rectangle(int d1, int d2) : GeometricShape(d1, d2) {}

    double CalcArea(){
        return  getD1() * getD2();
    }
};

class Square : public Rectangle{
public:
    Square(){}

    Square(int d) : Rectangle(d, d) {}

    void setD(int d){
        setD1(d);
        setD2(d);
    }

    int getD(){
        return getD1();
    }
};

double SumArea(GeometricShape* shapes[], int size){

    double sum = 0;

    for (int i = 0; i < size; ++i) sum+=(shapes[i]->CalcArea());

    return sum;
}

int main() {
    auto *r = new Rectangle(5,10);
    auto *s = new Square(5);
    auto *t = new Triangle(13,7);
    auto *c = new Circle(17);

    GeometricShape* shapes[] = {r, s, t, c};


    cout << "Rectangle area is: "<< r->CalcArea() << endl;
    cout << "Square area is: "<< s->CalcArea() << endl;
    cout << "Triangle area is: "<< t->CalcArea() << endl;
    cout << "Circle area is: "<< c->CalcArea() << endl;
    cout << "Sum of areas is: "<< SumArea(shapes, 4) << endl;

    _getch();
    return 0;
}
