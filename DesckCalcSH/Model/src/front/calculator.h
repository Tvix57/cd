#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <QMainWindow>
#include <QRegularExpression>
#include <QVector>

#include "qcustomplot.h"

#ifdef __cplusplus
extern "C" {
#endif

#include "calc.h"
#include "rpn.h"

#ifdef __cplusplus
}
#endif

QT_BEGIN_NAMESPACE
namespace Ui {
class Calculator;
}
QT_END_NAMESPACE

class Calculator : public QMainWindow {
  Q_OBJECT

 public:
  Calculator(QWidget *parent = nullptr);
  ~Calculator();

 private:
  Ui::Calculator *ui;
  bool read_x = false;
  int parenthesis = 0;
  QCustomPlot *Graph;
  double x_start, x_end;
  double y_start, y_end;
  double step;

 private slots:
  void press_digit();
  void press_operation();
  void press_function();
  void on_dot_clicked();
  void pres_parenthes();
  void on_equal_clicked();
  void on_clear_clicked();
  void on_variable_clicked();
  void on_basic_clicked();
  void on_credit_clicked();
  void on_deposit_clicked();
  void on_pushButton_clicked();
  void on_pushButton_2_clicked();
};
#endif  // CALCULATOR_H
