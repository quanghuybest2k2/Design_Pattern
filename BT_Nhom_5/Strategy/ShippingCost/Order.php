<?php
class Order
{
    private $weight;
    private $IShippingCost;

    public function __construct($weight, IShippingCost $IShippingCost)
    {
        $this->weight = $weight;
        $this->IShippingCost = $IShippingCost;
    }

    public function setShippingCost(IShippingCost $IShippingCost)
    {
        $this->IShippingCost = $IShippingCost;
    }

    public function totalCost()
    {
        return $this->IShippingCost->cost($this->weight);
    }
}
