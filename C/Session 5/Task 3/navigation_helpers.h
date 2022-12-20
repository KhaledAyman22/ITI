int UpKey(int current_row);
int DownKey(int current_row, int menu_size);
int LeftKey();
int RightKey();

int UpKey(int current_row){
    current_row = current_row == 0 ? current_row : current_row - 1;
    return  current_row;
}

int DownKey(int current_row, int menu_size){
    current_row = current_row == menu_size - 1 ? current_row : current_row + 1;
    return current_row;
}