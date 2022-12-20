#include <iostream>
#include <conio.h>
#include <windows.h>
#include <bits/stdc++.h>
using namespace std;

int CONS = 0, DES = 0;
unordered_set<string> addresses;

class Stack{
public:
    int* stack, top, size;


    Stack(Stack const &s){
        top = s.top;
        size = s.size;
        stack = new int [size];

        for (int i = 0; i < size; ++i) {
            stack[i] = s.stack[i];
        }
        CONS++;
        addresses.insert(this->GetAddress());
    }

    Stack(int _size){
        top = 0;
        size = _size;
        stack = new int [size];
        CONS++;
        addresses.insert(this->GetAddress());
    }

    ~Stack(){
        DES++;

        for (int i = 0; i < size; ++i) {
            stack[i] = -1;
        }

        delete []stack;
    }

    bool IsFull(){
        return top==size;
    }

    bool IsEmpty(){
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

    int GetCount(){
        return size - top - 1;
    }

    Stack Reverse(){
        Stack result(size);
        result.top = top;

        addresses.insert(result.GetAddress());
        addresses.insert(this->GetAddress());
        int j = 0;
        for (int i = top - 1; i > -1; --i) {
            result.stack[j] = stack[i];
            j++;
        }

        return result;
    }

    string GetAddress(){
        const void * address = static_cast<const void*>(this);
        stringstream ss;
        ss << address;
        return ss.str();
    }

    friend void ViewContent(Stack s);
};

void ViewContent(Stack s) {
    for (int i = 0; i < s.top; ++i) {
        cout << s.stack[i] << " ";
    }

    cout << endl;
}

int main() {

    int size = 5;


    Stack stack(size);

    stack.Push(5);
    stack.Push(4);
    stack.Push(3);
    int x = stack.Pop();

    cout << x << " is popped" << endl;

    ViewContent(stack);
    cout << endl;

    Stack s = stack.Reverse();

    ViewContent(s);
    cout << endl;

    cout << "Addresses of objects are:" << endl;
    for (const auto& elem: addresses) {
        cout << elem << endl;
    }

    cout << endl << endl;
    cout << "Number of constructors is: " << CONS << endl;

    cout << endl << endl;
    cout << "Number of destructors is: " << DES << endl;


    _getch();
    return 0;
}
