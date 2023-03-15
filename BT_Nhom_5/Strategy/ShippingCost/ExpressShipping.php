<?php
// giao hàng nhanh
class ExpressShipping implements IShippingCost
{
    public function cost($weight)
    {
        return currency_format(5000 * $weight);
    }
}
