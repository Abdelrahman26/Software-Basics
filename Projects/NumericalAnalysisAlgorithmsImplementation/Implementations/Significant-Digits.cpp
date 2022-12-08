#include <bits/stdc++.h>

using namespace std;

vector<int> findSignificantDigits(string n);

int main(){
    string n;
    
    while(cout << "Enter The Number: " && cin >> n){

        vector<int> ans;
        ans = findSignificantDigits(n);

        cout << "The number of Significant Digits = " << ans.size() << '\n';
        for(auto d : ans)
            cout << d << " ";
        cout << '\n';
    }

}

vector<int> findSignificantDigits(string n){
    vector<int> significant_digits;

    int length = n.size();
    int decimal_point_index = 0, left_most_significant_digit = -1, right_most_significant_digit = -1;

    for(int i = 0;i < length;i++){
        if(n[i] == '.')
            decimal_point_index = i;
        else if(n[i] > '0' && left_most_significant_digit == -1){
            left_most_significant_digit = i;
        }
        else if(n[i] > '0')
            right_most_significant_digit = i;
    }

    if(left_most_significant_digit == -1)
       return significant_digits;

    if(decimal_point_index == length - 1)
        decimal_point_index = 0;

    for(int i = 0;i < length;i++){
        if(n[i] == '.')continue;

        if(n[i] > '0'){
            significant_digits.push_back(n[i] - '0');
            continue;
        }

        if(i < left_most_significant_digit)
            continue;

        if(decimal_point_index || i < right_most_significant_digit)
            significant_digits.push_back(n[i] - '0');
    }

    return significant_digits;
}
