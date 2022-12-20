#include <iostream>
#include <conio.h>

using namespace std;

class Stack{
    int* stack, top, size;

public:
    Stack(int _size){
        top = 0;
        size = _size;
        stack = new int [size];
    }

    ~Stack(){
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
};

int main() {

    int choice, size;
    cout << "Enter stack size: ";
    cin >> size;

    Stack stack{size};

    while(true){
        cout << endl << endl;
        cout << "Press 1 to push, 2 to pop, 3 to peek, 4 to get count, 5 to exit" << endl;
        cin >> choice;


        switch (choice) {
            case 1: {
                cout << "Enter a number: ";
                int n;
                cin >> n;

                stack.Push(n);
                break;
            }

            case 2:{
                int tmp = stack.Pop();
                if(tmp!=-1)
                    cout << "Number " << tmp << " is popped" << endl;
                break;
            }

            case 3:{
                cout << "Number " << stack.Peek() << " is the top of the stack" << endl;
                break;
            }

            case 4:{
                cout << "There is " << stack.GetCount() << " elements in the stack" << endl;
                break;
            }

            case 5: { _getch(); return 0; }

            default: break;
        }
    }
}
