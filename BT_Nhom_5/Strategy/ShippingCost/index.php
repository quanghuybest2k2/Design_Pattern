<?php
require_once './convert_currency.php';
require_once './IShippingCost.php';
require_once './EconomyShipping.php';
require_once './ExpressShipping.php';
require_once './Order.php';

$order = new Order(5, new EconomyShipping());
echo $order->totalCost();
// Output: 15000
echo "<br/>";
$order->setShippingCost(new ExpressShipping());
echo $order->totalCost();
// Output: 25000
