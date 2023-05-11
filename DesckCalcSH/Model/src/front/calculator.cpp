

void Calculator::pres_parenthes() {
  QPushButton *button = (QPushButton *)sender();
  if (button->objectName() == "oparenthes") {
    static QRegularExpression regex("([+\\-*\\/^(]|mod)$");
    if (!ui->display->text().size() || ui->display->text().contains(regex)) {
      ui->display->setText(ui->display->text() + button->text());
      this->parenthesis++;
    }
  } else if (this->parenthesis) {
    static QRegularExpression regex("(\\d|[)]|x)$");
    if (ui->display->text().contains(regex)) {
      ui->display->setText(ui->display->text() + button->text());
      this->parenthesis--;
    }
  }
}

void Calculator::on_equal_clicked() {
  static QRegularExpression regex("(\\d|[\\)x])$");
  if (ui->display->text().contains(regex) && !this->parenthesis) {
    char str[256] = "";
    static QRegularExpression regex1("([+\\-*\\/^\\(A])([\\+])");
    static QRegularExpression regex2("([+\\-*\\/^\\(A])([\\-])");
    static QRegularExpression regex3("^[\\+]");
    static QRegularExpression regex4("^[\\-]");
    QString qstr = ui->display->text();
    qstr.replace("cos", "D").replace("sin", "E");
    qstr.replace("tan", "F").replace("acos", "G");
    qstr.replace("asin", "H").replace("atan", "I");
    qstr.replace("sqrt", "J").replace("ln", "K");
    qstr.replace("log", "L").replace("mod", "A");
    qstr.replace(regex1, "\\1B").replace(regex2, "\\1C");
    qstr.replace(regex3, "B").replace(regex4, "C");
    memcpy(str, (const char *)qstr.toStdString().c_str(), 256);
    Deque *rpn = init_deque();
    convert_to_rpn(rpn, str);
    if (this->read_x) {
      x_start = ui->xmin->value();
      x_end = ui->xmax->value();
      y_start = ui->ymin->value();
      y_end = ui->ymax->value();
      Graph->xAxis->setRange(x_start, x_end);
      Graph->yAxis->setRange(y_start, y_end);
      QVector<double> x, y;
      double rez;
      for (double X = x_start; X <= x_end; X += step)
        if (isfinite(rez = calculation(rpn, X))) {
          x.push_back(X);
          y.push_back(rez);
        }
      Graph->clearGraphs();
      Graph->addGraph();
      Graph->graph(0)->addData(x, y);
      Graph->replot();
      Graph->show();
      emit ui->clear->clicked(true);
    } else {
      ui->display->setText(QString::number(calculation(rpn, 0.0), 'g', 15));
    }
    d_free(rpn);
  }
}
