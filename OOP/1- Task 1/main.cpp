#include <iostream>
#include <conio.h>

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

        if(imaginary == 0 && real == 0)
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
};


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

    cout << "Complex 1 value is :";
    c1.Print();

    cout << "Complex 2 value is :";
    c2.Print();


    cout << "Summation of complex one and two is: ";
    Complex::Add(c1, c2).Print();

    cout << "Subtraction of complex one from two is: ";
    Complex::Subtract(c2, c1).Print();

    cout << "Subtraction of complex two from one is: ";
    Complex::Subtract(c1, c2).Print();

    _getch();

    return 0;
}
