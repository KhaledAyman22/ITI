#include <iostream>
#include <conio.h>
using namespace std;

class Stack{
    int* stack, top, size;

public:
    explicit Stack(int _size){
        top = 0;
        size = _size;
        stack = new int [size];
    }

    ~Stack(){
        delete []stack;
    }

    bool IsFull() const{
        return top==size;
    }

    bool IsEmpty() const{
        return top==0;
    }

    int Pop(){
        if(!IsEmpty()) return stack[--top];
        else {
            cout << "The stack is empty" << endl;
            return  -1;
        }
    }

    void Push(int n){
        if(!IsFull()) stack[top++] = n;
        else cout << "The stack is full";
    }

    int Peek(){
        if(!IsEmpty()) return stack[top-1];
        else {
            cout << "The stack is empty" << endl;
            return  -1;
        }
    }

    int GetCount() const{
        return size - top - 1;
    }

    Stack operator + (const Stack& s){
        Stack combined(size + s.size);

        for (int i = 0; i < top; ++i) {
            combined.Push(stack[i]);
        }

        for (int i = 0; i < s.top; ++i) {
            combined.Push(s.stack[i]);
        }

        return combined;
    }

    int operator [] (int i){
        if(i < size && i > -1)
            return stack[i];

        return INT32_MIN;
    }

    Stack& operator = (Stack const &s){
        delete[] stack;
        top = s.top;
        size = s.size;
        stack = new int[size];

        for (int i = 0; i < top; ++i) {
            stack[i] = s.stack[i];
        }

        return *this;
    }

    void Print(){
        for (int i = 0; i < top; ++i) {
            cout << stack[i] << " ";
        }

        cout << endl;
    }
};

int main() {
    int size = 5;

    Stack s1 (size), s2(3);

    s1.Push(1);
    s1.Push(2);
    s1.Push(3);

    cout << s1[2] << endl;

    s2 = s1;

    s2.Print();

    Stack s3 = s1 = s1 + s2;

    s1.Print();
    s2.Print();
    s3.Print();

    s1.Pop();
    s2.Pop();
    s2.Pop();
    s3.Pop();
    s3.Pop();
    s3.Pop();

    s1.Print();
    s2.Print();
    s3.Print();
    _getch();
    return 0;
}
