<?php
// giao tiêu chuẩn
class EconomyShipping implements IShippingCost
{
    public function cost($weight)
    {
        return currency_format(3000 * $weight);
    }
}
