import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductsServiceProxy,
  ProductDto,
  ProductTranslationDto,
  CategoriesServiceProxy,
  CategoryDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';

@Component({
  templateUrl: 'edit-product-dialog.component.html'
})
export class EditProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  public languages: abp.localization.ILanguageInfo[];
  langTranslation: ProductTranslationDto[] = [];
  product: ProductDto = new ProductDto();
  id: number;
  categories: CategoryDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _productService: ProductsServiceProxy,
    private _categoryService: CategoriesServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.languages = _filter(
      this.localization.languages,
      (l) => !l.isDisabled
    );
    this.languages.forEach(lang => {
      this.langTranslation[lang.name] = ProductTranslationDto.fromJS({
        language: lang.name
      });
    });
    this._categoryService.getAll('', 0, 100).subscribe(res => this.categories = res.items);
    this._productService.get(this.id).subscribe((result: ProductDto) => {
      this.product = result;
      this.languages.forEach(lang => {
        this.langTranslation[lang.name] = ProductTranslationDto.fromJS({
          name: this.product.translations?.find(pt => pt.language === lang.name)?.name ?? '',
          description: this.product.translations?.find(pt => pt.language === lang.name)?.description ?? '',
          language: lang.name
        });
      });
    });
    
  }

  save(): void {
    this.saving = true;

    this.product.translations = Object.keys(this.langTranslation).map(k => {
      if (this.langTranslation[k].name) {
        return this.langTranslation[k];
      } 
    }).filter(el => el);

    this._productService.update(this.product).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
