//#include "pch.h"
#include "deque.h"

Deque* init_deque(void) {
    Deque* temp = (Deque*)calloc((size_t)1, sizeof(Deque));
    temp->head = NULL;
    temp->tail = NULL;
    return temp;
}

lexeme_t* init_lexem(int type, va_list args) {
    lexeme_t* temp = (lexeme_t*)calloc((size_t)1, sizeof(lexeme_t));
    switch (type) {
    case OPERATION: {
        temp->type = OPERATION;
        temp->token.operation = va_arg(args, int);
        break;
    }
    case NUMBER: {
        temp->type = NUMBER;
        temp->token.number = va_arg(args, double);
        break;
    }
    case VARIABLE: {
        temp->type = VARIABLE;
        memset(&(temp->token), 0, sizeof(token_t));
    }
    }
    temp->next = NULL;
    temp->prev = NULL;
    return temp;
}

void d_push_f(Deque* deque, int type, ...) {
    va_list args;
    va_start(args, type);
    lexeme_t* temp = init_lexem(type, args);
    if (!deque) {
        deque = init_deque();
    }
    if (!deque->head) {
        deque->head = temp;
        deque->tail = temp;
    }
    else {
        temp->next = deque->head;
        deque->head->prev = temp;
        deque->head = temp;
    }
    va_end(args);
}

void d_push_b(Deque* deque, int type, ...) {
    va_list args;
    va_start(args, type);
    lexeme_t* temp = init_lexem(type, args);
    if (!deque) {
        deque = init_deque();
    }
    if (!deque->tail) {
        deque->head = temp;
        deque->tail = temp;
    }
    else {
        temp->prev = deque->tail;
        deque->tail->next = temp;
        deque->tail = temp;
    }
    va_end(args);
}

void d_push_lexem_b(Deque* deque, lexeme_t* lexeme) {
    if (!deque) {
        deque = init_deque();
    }
    if (!deque->tail) {
        deque->head = lexeme;
        deque->tail = lexeme;
    }
    else {
        lexeme->prev = deque->tail;
        deque->tail->next = lexeme;
        deque->tail = lexeme;
    }
}

int d_get_type_f(Deque* deque) {
    return deque->head ? (int)deque->head->type : -1;
}

bool d_get_operation_f(Deque* deque, int* value) {
    bool flag = false;
    if (d_get_type_f(deque) == OPERATION) {
        *value = deque->head->token.operation;
        flag = true;
    }
    return flag;
}

bool d_get_number_f(Deque* deque, double* value) {
    bool flag = false;
    if (d_get_type_f(deque) == NUMBER) {
        *value = deque->head->token.number;
        flag = true;
    }
    return flag;
}

lexeme_t* d_pop_lexem_f(Deque* deque) {
    lexeme_t* temp = deque->head;
    if (temp) {
        deque->head = temp->next;
        if (deque->head) {
            deque->head->prev = NULL;
            temp->next = NULL;
        }
    }
    if (!deque->head) {
        deque->tail = NULL;
    }
    return temp;
}

void d_free(Deque* deque) {
    lexeme_t* temp = NULL;
    while ((temp = d_pop_lexem_f(deque))) free(temp);
}
