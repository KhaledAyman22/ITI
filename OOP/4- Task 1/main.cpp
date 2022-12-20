#include <iostream>
#include <conio.h>
#include <string>
#include <cstring>


using namespace std;

class Complex{
    int real, imaginary;

public:

    Complex(){
        real = imaginary = 0;
    }

    Complex(int _real, int _imaginary){
        this->real = _real;
        this->imaginary = _imaginary;
    }

    int GetReal() const{
        return real;
    }

    int GetImaginary() const{
        return imaginary;
    }

    void SetReal(int _real){
        this->real = _real;
    }

    void SetImaginary(int complex){
        this->imaginary = complex;
    }

    static Complex Add(Complex complex1, Complex complex2){
        auto *c = new Complex(complex1.real + complex2.real,
                              complex1.imaginary + complex2.imaginary);

        return *c;
    }

    static Complex Subtract(Complex complex1, Complex complex2){
        auto *c = new Complex(complex1.real - complex2.real,
                              complex1.imaginary - complex2.imaginary);

        return *c;
    }

    void Print() const{
        bool real_is_zero = false;

        if(imaginary == real == 0)
        {
            cout << 0 << endl;
            return;
        }

        if(real != 0) cout << real;
        else real_is_zero = true;

        if(imaginary != 0){
            if(imaginary > 0 && !real_is_zero) cout << '+';

            cout << imaginary << 'i';
        }

        cout << endl;
    }

    string ToString() const{
        bool real_is_zero = false;
        string s = "";
        if(imaginary == 0 && real == 0)
        {
            cout << 0 << endl;
            s = "0";
            return s;
        }

        if(real != 0) s += to_string(real);
        else real_is_zero = true;

        if(imaginary != 0){
            if(imaginary > 0 && !real_is_zero) s += "+";

            s += (to_string(imaginary) + "i");
        }

        return s;
    }

    Complex operator + (Complex c) const{
        return {real+c.real,imaginary+c.imaginary};
    }

    Complex operator - (Complex c) const{
        return {real-c.real,imaginary-c.imaginary};
    }

    Complex operator + (int i) const{
        return {i + real, imaginary};
    }

    Complex operator - (int i) const{
        return {real - i, imaginary};
    }

    Complex& operator += (Complex c){
        real += c.real;
        imaginary += c.imaginary;
        return *this;
    }

    Complex& operator -= (Complex c){
        real -= c.real;
        imaginary -= c.imaginary;
        return *this;
    }

    Complex& operator += (int i){
        real += i;
        return *this;
    }

    Complex& operator -= (int i){
        real -= i;
        return *this;
    }

    bool operator == (Complex c) const{
        return (real == c.real) && (imaginary == c.imaginary);
    }

    bool operator != (Complex c) const{
        return (real != c.real) || (imaginary != c.imaginary);
    }

    bool operator >= (Complex c) const{
        if(real > c.real || (real == c.real && imaginary >= c.imaginary)) return true;
        else return false;
    }

    bool operator <= (Complex c) const{
        if(real < c.real || (real == c.real && imaginary <= c.imaginary)) return true;
        else return false;
    }

    bool operator > (Complex c) const{
        return (real > c.real) || (imaginary > c.imaginary);
    }

    bool operator < (Complex c) const{
        return (real < c.real) || (imaginary < c.imaginary);
    }

    Complex& operator ++ (){
        real++;
        return *this;
    }

    Complex operator -- (){
        real--;
        return *this;
    }

    Complex operator ++ (int){
        Complex tmp(*this);
        real++;
        return tmp;
    }

    Complex operator -- (int){
        Complex tmp(*this);
        real--;
        return tmp;
    }

    operator char*(){
        string s = ToString();
        char* val = new char[s.length()+1];
        strcpy(val, s.c_str());
        return val;
    }

    operator int(){
        return real;
    }
};

int operator + (const int& x, const Complex& c){
    return x+c.GetReal();
}

int operator - (const int& x, const Complex& c){
    return x-c.GetReal();
}

int operator -= (int& x, const Complex& c){
    return x -= c.GetReal();
}

int operator += (int& x, const Complex& c){
    return x += c.GetReal();
}

int main() {
    Complex c1;
    Complex c2;
    int tmp;


    cout << "Enter first complex real part: ";
    cin >> tmp;
    c1.SetReal(tmp);
    cout << endl;

    cout << "Enter first complex imaginary part: ";
    cin >> tmp;
    c1.SetImaginary(tmp);
    cout << endl;

    cout << "Enter second complex real part: ";
    cin >> tmp;
    c2.SetReal(tmp);
    cout << endl;

    cout << "Enter second complex imaginary part: ";
    cin >> tmp;
    c2.SetImaginary(tmp);
    cout << endl;

    cout << "Complex 1 value is : ";
    c1.Print();

    cout << "Complex 2 value is : ";
    c2.Print();


    cout << "Summation of complex one and two is: " << endl;
    (c1+c2).Print();


    cout << "Subtraction of complex one from two is: " << endl;
    (c2-c1).Print();

    cout << "Subtraction of complex two from one is: " << endl;
    (c1-c2).Print();

    cout << "Complex 1 value is : ";
    c1.Print();

    cout << "Complex 2 value is : ";
    c2.Print();

    cout << "Complex one ++ prefix is: " << endl;
    (++c1).Print();

    cout << "Complex 1 value is : ";
    c1.Print();

    cout << "Complex 2 value is : ";
    c2.Print();

    cout << "Complex one ++ suffix is: " << endl;
    (c1++).Print();

    cout << "Complex 1 value is : ";
    c1.Print();

    cout << "Complex 2 value is : ";
    c2.Print();

    cout << "Complex one > Complex two?: " << (c1 > c2) << endl;
    cout << "Complex one < Complex two?: " << (c1 < c2) << endl;
    cout << "Complex one >= Complex two?: " << (c1 >= c2) << endl;
    cout << "Complex one <= Complex two?: " << (c1 <= c2) << endl;

    cout << "Complex one to int: " << (int)c1 << endl;
    cout << "Complex one to char: " << (char)c1 << endl;

    char* c = c1;
    int i=0;
    while(c[i]!='\0'){
        cout << c[i];
        i++;
    }

    int x = 1+c1;


    _getch();

    return 0;
}
