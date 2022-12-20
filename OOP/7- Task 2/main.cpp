#include <iostream>
#include <graphics.h>
#include <conio.h>

class Shape{
    int color;

public:
    explicit Shape(int color) : color(color) {}

    int getColor() const {
        return color;
    }

    virtual void Draw()=0;
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

    int GetY() const {
        return y;
    }
};

class MyRectangle : public Shape{
    MyPoint upper, lower;

public:
    MyRectangle(int _x1, int _y1, int _x2, int _y2, int _color)
            : Shape(_color), upper(_x1, _y1), lower(_x2, _y2){}

    void Draw() override{
        setcolor(getColor());
        rectangle(upper.GetX(), upper.GetY(),
                  lower.GetX(), lower.GetY());
    }

};

class MyCircle : public Shape{
    MyPoint center;
    int radius{};

public:
    MyCircle(int _x, int _y, int _radius, int _color) : Shape(_color), center(_x, _y)
    {
        radius = _radius;
    }

    void Draw() override{
        setcolor(getColor());
        circle(center.GetX(), center.GetY(), radius);
    }

};

class MyLine : public Shape{
    MyPoint p1, p2;

public:
    MyLine(int _x1, int _y1, int _x2, int _y2, int _color)
            : Shape(_color), p1(_x1, _y1), p2(_x2, _y2){}

    MyLine(const MyLine &line) : Shape(line.getColor()){
        p1 = line.p1;
        p2 = line.p2;
    }

    void Draw() override{
        setcolor(getColor());
        line(p1.GetX(), p1.GetY(),
             p2.GetX(), p2.GetY());
    }

};

class MyTriangle : public Shape {
    MyLine l1, l2, l3;

public:
    MyTriangle(const MyLine &l1, const MyLine &l2, const MyLine &l3, int color) : Shape(color),l1(l1),l2(l2),l3(l3){}

    void Draw() override{
        l1.Draw();
        l2.Draw();
        l3.Draw();
    }
};

class Picture01{
    MyRectangle** rectangles;
    MyTriangle** triangles;
    MyCircle** circles;
    MyLine** lines;
    int rs,ts,cs,ls;

public:
    Picture01(MyRectangle *rectangles[], MyTriangle *triangles[], MyCircle *circles[], MyLine *lines[], int rs, int ts, int cs,
              int ls) : rectangles(rectangles), triangles(triangles), circles(circles), lines(lines), rs(rs), ts(ts),
                        cs(cs), ls(ls) {}

    void Paint(){
        for (int i = 0; i < rs; ++i) rectangles[i]->Draw();
        for (int i = 0; i < cs; ++i) circles[i]->Draw();
        for (int i = 0; i < ts; ++i) triangles[i]->Draw();
        for (int i = 0; i < ls; ++i) lines[i]->Draw();

    }
};

class Picture02{
    Shape **shapes;
    int size;

public:
    Picture02(Shape *shapes[], int size) : shapes(shapes), size(size) {}

    void Paint(){
        for (int i = 0; i < size; ++i) shapes[i]->Draw();
    }

};

int main() {
    //Lines for triangle
    MyLine t1(383,433,395,467,1),
            t2(383,433,371,464,1),
            t3(371,464,395,467,1);


    initgraph();

    // NO POLYMORPHISM

    MyRectangle* rectangles[] = { new MyRectangle (356, 425, 677, 500, 1)};

    MyLine* lines[] = { new MyLine(488, 422, 490, 318, 1),
                        new MyLine(561, 422, 558, 318, 1),
                        new MyLine(602, 254, 571, 101, 1),
                        new MyLine(447, 254, 476, 101, 1)};

    MyCircle* circles[] = {new MyCircle(524,278,140,5),
                           new MyCircle(513,99,50,5)};

    MyTriangle* triangles[] = {new MyTriangle (t1,t2,t3,1)};



    Picture01 p01(rectangles, triangles, circles, lines, 1, 4, 2, 1);
    p01.Paint();

    Sleep(5000);
    system("cls");
    //WITH POLYMORPHISM

    Shape *shapes[] = {
            new MyRectangle (356, 425, 677, 500, 1),
            new MyLine(488, 422, 490, 318, 1),
            new MyLine(561, 422, 558, 318, 1),
            new MyLine(602, 254, 571, 101, 1),
            new MyLine(447, 254, 476, 101, 1),
            new MyCircle(524,278,140,5),
            new MyCircle(513,99,50,5),
            new MyTriangle (t1,t2,t3,1)
    };

    Picture02 p02(shapes, 8);
    p02.Paint();

    _getch();
    return 0;
}