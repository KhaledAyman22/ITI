#include <iostream>
#include <graphics.h>
#include <conio.h>

class ShapeColor{
    int color;

public:
    ShapeColor(int color) : color(color) {}

    int getColor() const {
        return color;
    }

    void setColor(int color) {
        ShapeColor::color = color;
    }
};

class MyPoint{
    int x,y;
public:
    MyPoint(){
        x = y = 0;
    }

    MyPoint(int _x, int _y){
        x = _x;
        y = _y;
    }

    MyPoint(MyPoint &p){
        x = p.x;
        y = p.y;
    }

    int GetX() const {
        return x;
    }

    void SetX(int _x) {
        x = _x;
    }

    int GetY() const {
        return y;
    }

    void SetY(int _y) {
        y = _y;
    }

    void Show() const{
        cout << x << ", " << y << endl;
    }
};

class MyRectangle : public ShapeColor{
    MyPoint upper, lower;

public:
    MyRectangle(int _color) : ShapeColor(_color){}

    MyRectangle(int _x1, int _y1, int _x2, int _y2, int _color)
    : ShapeColor(_color), upper(_x1, _y1), lower(_x2, _y2){}

    void Draw(){
        setcolor(getColor());
        rectangle(upper.GetX(), upper.GetY(),
                  lower.GetX(), lower.GetY());
    }

};

class MyCircle : public ShapeColor{
    MyPoint center;
    int radius;

public:
    MyCircle(int _color) : ShapeColor(_color){}

    MyCircle(int _x, int _y, int _radius, int _color) : ShapeColor(_color), center(_x, _y)
    {
        radius = _radius;
    }

    void Draw(){
        setcolor(getColor());
        circle(center.GetX(), center.GetY(), radius);
    }

};

class MyLine : public ShapeColor{
    MyPoint p1, p2;

public:
    MyLine(int _color) : ShapeColor(_color){}

    MyLine(int _x1, int _y1, int _x2, int _y2, int _color)
            : ShapeColor(_color), p1(_x1, _y1), p2(_x2, _y2){}

    MyLine(MyLine &line) : ShapeColor(line.getColor()){
        p1 = line.p1;
        p2 = line.p2;
    }

    void Draw(){
        setcolor(getColor());
        line(p1.GetX(), p1.GetY(),
             p2.GetX(), p2.GetY());
    }

};

class MyTriangle {
    MyLine l1, l2, l3;

public:
    MyTriangle(int _color) : l1(_color), l2(_color), l3(_color) {}

    MyTriangle(MyLine _l1, MyLine _l2, MyLine _l3, int _color)
            : l1(_l1), l2(_l2), l3(_l3) {}

    void Draw(){
        l1.Draw();
        l2.Draw();
        l3.Draw();
    }

};

int main() {
    initgraph();

    MyRectangle r(356, 425, 677, 500, 1);

    MyLine l1(488, 422, 490, 318, 1),
            l2(561, 422, 558, 318, 1),
            l3(602, 254, 571, 101, 1),
            l4(447, 254, 476, 101, 1);

    MyCircle c1(524,278,140,5),
            c2(513,99,50,5);


    MyLine t1(383,433,395,467,1),
            t2(383,433,371,464,1),
            t3(371,464,395,467,1);


    MyTriangle t(t1,t2,t3,1);

    r.Draw();
    l1.Draw();
    l2.Draw();
    l3.Draw();
    l4.Draw();
    c1.Draw();
    c2.Draw();
    t.Draw();

    _getch();
    return 0;
}
