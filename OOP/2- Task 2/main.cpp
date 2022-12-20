#include <iostream>
#include <conio.h>
#include <windows.h>

using namespace std;

class Queue{
    int* queue, size, tail;

public:
    Queue(int _size){
        size = _size;
        tail = 0;
        queue = new int[size];
    }

    ~Queue(){
        delete []queue;
    }

    bool IsFull(){
        return tail == size;
    }

    bool IsEmpty(){
        return tail == 0;
    }

    void Enqueue(int n){
        if(!IsFull()) queue[tail++] = n;
        else cout << "The queue is full";
    }

    int Dequeue(){
        if(!IsEmpty()){
            int tmp = queue[0];

            for (int i = 0; i < tail-1; ++i) {
                queue[i] = queue[i+1];
            }
            tail--;
            return tmp;
        }
        else{
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    int Peek(){
        if(!IsEmpty()) return queue[0];
        else {
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    int GetCount(){
        return tail;
    }

};


int main() {

    int choice, size;
    cout << "Enter queue size: ";
    cin >> size;

    Queue queue{size};

    while(true){
        cout << endl << endl;
        cout << "Press 1 to enqueue, 2 to dequeue, 3 to peek, 4 to get count, 5 to exit" << endl;
        cin >> choice;


        switch (choice) {
            case 1: {
                cout << "Enter a number: ";
                int n;
                cin >> n;

                queue.Enqueue(n);
                break;
            }

            case 2:{
                int tmp = queue.Dequeue();
                if(tmp!=-1)
                    cout << "Number " << tmp << " is dequeued" << endl;
                break;
            }

            case 3:{
                int tmp = queue.Peek();
                if(tmp!=-1)
                    cout << "Number " << tmp << " is the front of the queue" << endl;
                break;
            }

            case 4:{
                cout << "There is " << queue.GetCount() << " elements in the queue" << endl;
                break;
            }

            case 5: { _getch(); return 0; }

            default: break;
        }
    }
}

