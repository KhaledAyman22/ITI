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
    
    int CalcArea(){
        return d1*d2;
    }
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
        return 3.14 * GeometricShape::CalcArea();
    }
};

class Triangle : public GeometricShape{
public:
    Triangle(){}

    Triangle(int d1, int d2) : GeometricShape(d1, d2) {}

    double CalcArea(){
        return 0.5 * GeometricShape::CalcArea();
    }
};

class Rectangle : public GeometricShape{
public:
    Rectangle(){}

    Rectangle(int d1, int d2) : GeometricShape(d1, d2) {}
};

class Square : protected Rectangle{
public:
    Square(){}

    Square(int d) : Rectangle(d, d) {}

    void setD(int d){
        setD1(d);
        setD2(d);
    }

    int CalcArea(){
        return  Rectangle::CalcArea();
    }
};

int SumArea(Rectangle *r, Square *s, Triangle *t, Circle *c,
            int rs, int ss, int ts, int cs){

    int sum = 0;

    for (int i = 0; i < rs; ++i) sum+=r[i].CalcArea();
    for (int i = 0; i < ss; ++i) sum+=s[i].CalcArea();
    for (int i = 0; i < ts; ++i) sum+=t[i].CalcArea();
    for (int i = 0; i < cs; ++i) sum+=c[i].CalcArea();

    return sum;
}

int main() {
    int cr,cs,ct,cc;
    cr=cs=ct=cc=0;

    auto* r_arr = new Rectangle[5];
    auto* s_arr = new Square[5];
    auto* t_arr = new Triangle[5];
    auto* c_arr = new Circle[5];

    Rectangle r(5,10);
    Square s(5);
    Triangle t(13,7);
    Circle c(17);

    r_arr[cr++] = r;
    s_arr[cs++] = s;
    t_arr[ct++] = t;
    c_arr[cc++] = c;


    cout << "Rectangle area is: "<< r.CalcArea() << endl;
    cout << "Square area is: "<< s.CalcArea() << endl;
    cout << "Triangle area is: "<< t.CalcArea() << endl;
    cout << "Circle area is: "<< c.CalcArea() << endl;
    cout << "Sum of areas is: "<< SumArea(r_arr,s_arr,t_arr,c_arr,cr,cs,ct,cc) << endl;

    _getch();
    return 0;
}
