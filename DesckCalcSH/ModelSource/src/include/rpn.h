#ifndef SRC_INCLUDE_RPN_H_
#define SRC_INCLUDE_RPN_H_

#include <ctype.h>

#include "deque.h"

int get_priority(int op);
bool is_operation(int op);
int is_less_eq_p(int op1, int op2);
bool is_function(int op);

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport) void convert_to_rpn(Deque *rpn, const char *infix);

#ifdef __cplusplus
}
#endif
#endif  // SRC_INCLUDE_RPN_H_
