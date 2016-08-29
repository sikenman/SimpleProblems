#include <iostream>
#include <cstdio>
using namespace std;

/* Returns maximum among the four integers
 * Author: Siken Man Singh Dongol 
 */
 
int max_of_four(int a, int b, int c, int d) {
    int ab;
    int cd;
    if(a>=b) ab=a; else ab = b;
    if(c>=d) cd=c; else cd = d;
    
    int max;
    if(ab>=cd) max=ab; else max=cd;
    
    return max;
}

int main() {
    int a, b, c, d;
    scanf("%d %d %d %d", &a, &b, &c, &d);
    int ans = max_of_four(a, b, c, d);
    printf("%d", ans);
    
    return 0;
}
