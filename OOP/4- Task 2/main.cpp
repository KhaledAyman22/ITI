#include <iostream>
#include <conio.h>

using namespace std;

class IntArray{
    int* arr, size;

public:
    IntArray(int s){
        size = s;
        arr = new int[size];
    }

    IntArray(const IntArray& array){
        IntArray new_array(array.size);

        for (int i = 0; i < array.size; ++i) {
            new_array[i] = arr[i];
        }
    }

    ~IntArray(){
        delete[] arr;
    }

    IntArray& operator = (const IntArray& array){
        delete[] arr;
        arr = new int[array.size];

        for (int i = 0; i < array.size; ++i) {
            arr[i] = array.arr[i];
        }

        return *this;
    }


    int& operator [](int i){
        if(i < size && i > -1)
            return arr[i];
    }

    int GetSize(){
        return size;
    }
};

int main() {
    IntArray my_array(5);

    my_array[0] = 1;
    my_array[1] = 2;
    my_array[2] = 3;
    my_array[3] = 4;
    my_array[4] = 5;

    cout << my_array[2] + my_array[1] << endl; // 5

    my_array[0] = my_array[1] + my_array[2];

    cout << my_array[0] << endl; //5

    _getch();
    return 0;
}
