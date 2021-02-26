<template>
    <div id="fee-list">
        <div class="menu">
            <div class="menu__tab">Quy trình</div>
            <div class="menu__tab current--tab">Danh sách khoản thu</div>
            <div class="menu__tab">Đăng ký khoản thu</div>
            <div class="menu__tab">danh sách miễn giảm</div>
        </div>
        <div class="option">
            <div class="option__item float--left">
                <input type="checkbox" id="displayFeeInActive" v-model="showFeeInactive"/>
                <label for="displayFeeInActive"><span></span>Hiển thị khoản thu ngừng theo dõi</label>
            </div>
            <div class="option__item float--right">
                <button class="m-icon-button icon-delete" @click="btnDeleteOnClick_n" :disabled="!haveRowOnSelect"></button>
            </div>
            <div class="option__item float--right">
                <button class="m-second-button" @click="loadData">Sắp lại thứ tự</button>
            </div>
            <div class="option__item float--right">
                <button class="m-button" @click="btnAddOnClick">Thêm mới</button>
            </div>
        </div>
        <div v-if="isLoading" class="loading icon-loading">
            
        </div>
        <div class="table">
            <table>
                <thead>
                    <tr class="odd-row">
                        <th class="select-col">
                            <!-- <input type="checkbox" id="0" v-model="selectAllRows"/>
                            <label for="0"><span></span></label> -->
                        </th>
                        <th v-for="col in listCol" :key="col.key" :class="col.key">{{col.title}}</th>
                        <th class="option-col"></th>
                    </tr>
                </thead>
                <tbody v-if="!isLoading">
                    <tr v-for="(fee, index) in listFee.filter((_fee) => {
                            return ( _fee && (_fee.IsActive || showFeeInactive));
                        })" :key="index" 
                        :class="{'odd-row': index%2 === 1, 'row-on-select': feeIds[fee.FeeID] === true}">
                        <td class="select-col">
                            <input type="checkbox" :id="fee.FeeID" v-model="feeIds[fee.FeeID]"/>
                            <label :for="fee.FeeID"><span></span></label>
                        </td>
                        <td v-for="col in listCol" :key="col.key" :class="col.key">
                            <span v-if="col.key === 'FeeName'" class="m-flex">
                                <span @click="btnEditOnClick(fee.FeeID)" class="text-FeeName">{{fee[col.key]}}</span>
                                <span v-if="fee.IsSystem" class="icon-i" title="Đây là khoản thu mặc định của hệ thống, bạn không thể xóa."></span>
                            </span>
                            <div v-else-if="col.key === 'Price'" class="m-text-right">
                                {{fee | priceRate}}
                            </div>
                            <div v-else-if="col.key === 'Period'">
                                {{fee | periodName}}
                            </div>
                            <div v-else-if="isBool(fee[col.key])" class="cell-center">
                                <div :class="{'icon-checkbox': true, 'icon-check': fee[col.key]}"></div>
                            </div>
                            <span v-else-if="col.key !== 'FeeName'">{{fee[col.key]}}</span>
                        </td>
                        <td class="option-col">
                            <div class="m-flex">
                                <div class="icon icon-edit" @click="btnEditOnClick(fee.FeeID)"></div>
                                <div class="icon icon-duplicate" @click="btnDuplicateOnClick(fee.FeeID)"></div>
                                <div class="icon icon-delete" @click="btnDeleteOnClick_1(fee.FeeID)"></div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="footer">Tổng số: {{listFee.filter((_fee) => {
                            return ( _fee && (_fee.IsActive || showFeeInactive));
                        }).length}} kết quả</div>
        <FeeListDetail v-if="formDetail" @close="closeForm" :mode="formMode" :listFeeGroup="listFeeGroup" :feeId="feeIdChange" @reloadData="loadData"/>
        <FeeListDelete v-if="dialogDelete" @close="dialogDelete = false" @reloadData="loadData" 
            :message="messageDelete" :mode="formMode" :listFeeId="listFeeIdDelete"/>
    </div>
</template>
<script>
import FeeListDetail from './FeeListDetail'
import FeeListDelete from './FeeListDelete'
import axios from 'axios'

export default {
    data() {
        return {
            //danh sách thông tin được hiển thị trên bảng
            listCol: [
                {
                    key: "FeeName",
                    title: "Tên khoản thu"
                },
                {
                    key: "FeeGroupName",
                    title: "Nhóm khoản thu"
                },
                {
                    key: "Price",
                    title: "Mức thu"
                },
                {
                    key: "Period",
                    title: "Kỳ thu"
                },
                {
                    key: "",
                    title: "Thời điểm thu"
                },
                {
                    key: "IsApplyRemisson",
                    title: "Áp dụng miễn giảm"
                },
                {
                    key: "AllowCreateInvoice",
                    title: "Cho xuất hóa đơn"
                },
                {
                    key: "AllowCreateReceipt",
                    title: "Cho xuất chứng từ"
                },
                {
                    key: "IsInternal",
                    title: "Cho phép hoàn trả"
                },
                {
                    key: "IsRequire",
                    title: "Khoản thu bắt buộc"
                },
                {
                    key: "IsActive",
                    title: "Đang theo dõi"
                }
            ],
            //danh sách khoản thu
            listFee: [],
            //danh sách nhóm khoản thu
            listFeeGroup: [],
            //Đối tượng quản lý các khoản thu được chọn
            feeIds: {},
            //trạng thái đóng/mở của FeeListDetail
            formDetail: false,
            //Trạng thái đóng/mở của FeeListDelete
            dialogDelete: false,
            //cách thức hoạt động của các dialog: ADD - Thêm mới, EDIT - Sửa, DELETE - Xóa, NOTIFICATION - Thông báo
            formMode: null,
            //feeId được truyền vào để load dữ liệu trong FeeListDetail
            feeIdChange: null,
            //Hiển thị các khoản thu ngừng theo dõi
            showFeeInactive: false,
            //Thông báo trong FeeListDelete
            messageDelete: "",
            //Danh sách feeId truyền vào FeeListDelete để thực hiện xóa
            listFeeIdDelete: [],
            //Đang tải dữ liệu vào listFee
            isLoading: true,
        }
    },
    components: {
        FeeListDetail,
        FeeListDelete
    },
    mounted() {
        //Lấy danh sách nhóm khoản thu
        axios.get('http://localhost:60931/api/v1/FeeGroups')
            .then(res => {
                this.listFeeGroup = res.data;
            })
            .catch(res => {
                alert(res);
            })
        this.loadData();
    },
    methods: {
        //Click vào button thêm mới
        //Created by Phạm Việt Thắng (20/02/2021)
        btnAddOnClick() {
            this.feeIdChange = null;
            this.formMode = "ADD";
            this.formDetail = true;
        },
        //Click vào button xóa
        //Created by Phạm Việt Thắng (20/02/2021)
        btnEditOnClick(FeeID) {
            this.feeIdChange = FeeID;
            this.formMode = "EDIT";
            this.formDetail = true;
        },
        //Click vào button nhân bản
        //Created by Phạm Việt Thắng (20/02/2021)
        btnDuplicateOnClick(feeId) {
            this.feeIdChange = feeId;
            this.formMode = "ADD";
            this.formDetail = true;
        },
        ///Click vào button xóa trong table
        //Created by Phạm Việt Thắng (20/02/2021)
        btnDeleteOnClick_1(feeId) {
            if (this.listFee.filter((fee) => {
                return fee.FeeID === feeId;
            })[0].IsSystem === true) {
                this.formMode = "NOTIFICATION";
                this.messageDelete = "Bạn không thể xóa dữ liệu của hệ thống.";
            } else {
                this.listFeeIdDelete = [];
                this.listFeeIdDelete.push(feeId);
                this.formMode = "DELETE";
                this.messageDelete = "Bạn có chắc chắn muốn xóa khoản thu đã chọn?";
            }
            this.dialogDelete = true;
        },
        //Click vào button xóa những khoản thu được chọn
        //Created by Phạm Việt Thắng (20/02/2021)
        btnDeleteOnClick_n() {
            this.listFeeIdDelete = [];
            for (let feeId in this.feeIds) {
                if (this.feeIds[feeId] === true) {
                    let fee_ = this.listFee.filter((fee) => {
                        return fee.FeeID == feeId;
                    })[0];
                    if (typeof fee_ !== undefined && fee_ !== null && fee_.IsSystem === true) {
                        this.formMode = "NOTIFICATION";
                        this.messageDelete = "Bạn không thể xóa dữ liệu của hệ thống.";
                        this.dialogDelete = true;
                        return;
                    } else if (fee_.IsActive || this.showFeeInactive) {
                        this.listFeeIdDelete.push(feeId);
                    }
                }
            }
            this.formMode = "DELETE";
            if (this.listFeeIdDelete.length > 1) 
                this.messageDelete = "Bạn có chắc chắn muốn xóa những khoản thu đã chọn?";
            else 
                this.messageDelete = "Bạn có chắc chắn muốn xóa khoản thu đã chọn?";
            this.dialogDelete = true;
        },
        //Đóng các dialog
        //Created by Phạm Việt Thắng (20/02/2021)
        closeForm() {
            this.formMode = null;
            this.formDetail = false;
            this.dialogDelete = false;
            this.messageDelete = "";
            this.listFeeIdDelete = [];
        },
        //Lấy dữ liệu từ server
        //Created by Phạm Việt Thắng (20/02/2021)
        async loadData() {
            this.isLoading = true;
            this.listFee = [];
            //Lấy danh sách khoản thu
            await axios.get('http://localhost:60931/api/v1/Fees')
                .then(res => {
                    this.listFee = res.data;
                    for (let feeId in this.feeIds) {
                        if (this.listFee.filter((fee) => {
                            return fee.FeeID == feeId;
                        }).length == 0) {
                            this.feeIds[feeId] = false;
                        }
                    }
                    this.isLoading = false;
                })
                .catch(res => {
                    console.log(res);
                    this.feeIds = this.feeIds.filter((feeId) => {
                        return this.listFee.filter((fee) => {
                            return fee.FeeID == feeId;
                        }).length > 0;
                    })
                    this.isLoading = false;
                })
        },
        //Kiểm tra giá trị truyền vào có phải kiểu bool hay không
        //Created by Phạm Việt Thắng (20/02/2021)
        isBool(val) {
            if (typeof val === typeof true) 
                return true;
            return false;
        }
    },
    computed: {
        //Kiểm tra xem có dòng nào đang được chọn hay không
        haveRowOnSelect() {
            for (let feeId in this.feeIds) {
                if (this.feeIds[feeId] === true) {
                    let fee_ = this.listFee.filter((fee) => {
                        return fee.FeeID == feeId;
                    })[0];
                    if (fee_ && (fee_.IsActive || this.showFeeInactive)) {
                        return true;
                    }
                }
            }
            return false;
        },
    },
    filters: {
        //Format mức thu về dạng fee.Price/fee.Unit
        //Created by Phạm Việt Thắng (20/02/2021)
        priceRate(fee) {
            var result = "";
            var price = fee.Price;
            var i = 0
            while (price > 0) {
                if (i !== 0 && i%3==0) {
                    result = '.' + result;
                }
                result = (price%10) + result;
                price = Math.floor(price/10);
                ++i;
            }
            switch (fee.Unit) {
                case 1:
                    result += "/ngày"
                    break;
                case 2:
                    result += "/tuần"
                    break;
                case 3:
                    result += "/tháng"
                    break;
                case 4:
                    result += "/học kỳ"
                    break;
                case 5:
                    result += "/năm"
                    break;
                default:
                    break;
            }
            return result;
        },
        //Format kỳ thu về dạng text
        //Created by Phạm Việt Thắng (20/02/2021)
        periodName(fee) {
            switch (fee.Period) {
                case 1:
                    return "Tháng";
                case 2:
                    return "Quý";
                case 3:
                    return "Học kỳ";
                case 4:
                    return "Năm học"
                default:
                    return "";
            }
        }
    },

}
</script>
<style>
#fee-list {
    width: 100%;
    height: 100%;
    overflow: hidden;
}

.menu {
    display: flex;
    width: 100%;
    height: 40px;
    background-color: #F6F6F6;
    overflow: hidden;
}

    .menu .menu__tab {
        height: calc(40px - 3px);
        padding-left: 20px;
        padding-right: 20px;
        color: #CCCCCC;
        border-top: 3px solid #E9E9E9;
        display: flex;
        align-items: center;
        cursor: pointer;
    }

    .menu .menu__tab.current--tab {
        border-top: 3px solid #0E9D50;
        color: #0E9D50;
        background-color: #fff;
        z-index: 3;
    }

.option {
    width: calc(100% - 24px);
    height: 50px;
    padding: 0px 12px 0px 12px;
    overflow: hidden;
}

    .option .option__item {
        height: 100%;
        display: flex;
        align-items: center;
        margin-left: 8px;
    }

    .option .option__item.float--left {
        margin-left: 0;
    }

.loading{
    position: absolute;
    width: 75px;
    height: 20px;
    left: calc((100% - 75px) / 2);
    bottom: calc((100% - 60px) / 2);
}

.table {
    width: calc(100% - 24px);
    height: calc(100% - 40px - 50px - 50px);
    margin: 0 12px 0 12px;
    overflow-x: auto;
    overflow-y: hidden;
}

        .table::-webkit-scrollbar {
        width: 6px;
        height: 6px;
        background-color: #E9EBEE;
    }

        .table::-webkit-scrollbar-thumb {
        width: 6px;
        height: 6px;
        background-color: #bbbbbb;
    }

        .table table {
            width: 100%;
            min-width: 1672px;
            height: 100%;
            border-collapse: collapse;
            border: 1px solid #e9e9e9;
        }

            .table table thead {
                width: calc(100% - 8px);
                background-color: #0E9D50;
            }

            .table table tbody {
                display: block;
                height: calc(100% - 10px);
                overflow-y: auto;
                overflow-x: hidden;
            }

                .table table tbody::-webkit-scrollbar {
                    width: 4px;
                    height: 6px;
                    background-color: #E9EBEE;
                }

                .table table tbody::-webkit-scrollbar-thumb {
                    width: 4px;
                    height: 6px;
                    background-color: #bbbbbb;
                }

            .table table tr {
                width: 100%;
                display: table;
                table-layout: fixed;
                height: 40px;
            }

            .table table td, .table table th {
                border: 1px solid #e9e9e9;
                padding: 0 8px 0 8px;
            }

            .table table .select-col {
                text-align: center;
                width: 30px;
                min-width: 30px;
            }

            .table table .option-col {
                width: 72px;
            }
/* 
            .table table th.option-col {
                width: 78px;
            } */

                .table table .option-col .icon {
                    width: 20px;
                    height: 20px;
                    cursor: pointer;
                    margin: 0 2px 0 2px;
                }

            .table table .odd-row {
                background-color: #F5F6FA;
            }

            .table table .row-on-select {
                background-color: #cce8ff;
            }

            .table table .text-FeeName {
                line-height: 20px;
                color: #0997eb;
                cursor: pointer;
                overflow: hidden;
                text-overflow: ellipsis;
            }

            .table table .icon-i {
                width: 20px;
                height: 20px;
                cursor: pointer;
                margin: 0 8px 0 8px;
            }

            .table table .FeeName {
                width: 20%;
            }

            .table table .icon-checkbox {
                width: 20px;
                height: 20px;
            }

            .table table .cell-center {
                display: flex;
                justify-content: center;
                width: 100px;
            }

.footer {
    width: calc(100% - 24px);
    height: 50px;
    padding: 0 12px 0 12px;
    display: flex;
    align-items: center;
    overflow: hidden;
}

#notification {
    display: none;
}

#notification .modal {
    position: fixed;
    width: 100vw;
    height: 100vh;
    top: 0;
    left: 0;
    background-color: #cccccc;
    opacity: 0.6;
    z-index: 3;
}

#notification .dialog {
    position: fixed;
    z-index: 3;
    width: calc(1000px - 24px - 24px);
    height: 600px;
    top: calc((100vh - 600px) / 2);
    left: calc((100vw - 1000px) / 2);
    background-color: #fff;
    border-radius: 4px;
    padding-left: 24px;
    padding-right: 24px;
    overflow: hidden;
}
</style>