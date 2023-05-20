#pragma once

#include <ctype.h>
#include "deque.h"

#ifdef MODELLIB2_EXPORTS
#define MODELLIB2_API __declspec(dllexport)
#else
#define MODELLIB2_API __declspec(dllimport)
#endif

extern "C" MODELLIB2_API void convert_to_rpn(Deque * rpn, const char* infix);

int get_priority(int op);
bool is_operation(int op);
int is_less_eq_p(int op1, int op2);
bool is_function(int op);
