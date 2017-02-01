select ml.location_name, mp.product_id, mp.product_name, mp.product_stock_qty, pl.product_location_qty, pl.location_id 
from master_product mp, product_location pl, master_location ml 
where mp.product_id = 105 and pl.product_id = mp.product_id and pl.location_id = ml.id